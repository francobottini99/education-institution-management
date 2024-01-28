using AutoMapper;
using Capa.Datos.Datos;
using Capa.Datos.Modelos;
using Capa.Datos.Repositorios;
using Capa.Datos.Repositorios.Implementaciones;
using Capa.Negocio.DTO;
using Capa.Negocio.Mapeo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capa.Negocio.Servicios.Implementacion
{
    public class ServicioPerfilUsuario : IServicioPerfilUsuario
    {
        private readonly IMapper mapeador;
        private readonly IRepositorioPerfilUsuario repositorioPerfil;
        private readonly IRepositorioDetallePerfilUsuario repositorioDetalle;
        private readonly IRepositorioUsuario repositorioUsuario;

        public ServicioPerfilUsuario()
        {
            repositorioPerfil = new RepositorioPerfilUsuario();
            repositorioDetalle = new RepositorioDetallePerfilUsuario();
            repositorioUsuario = new RepositorioUsuario();
            mapeador = MapperConfig.GetInstance().CreateMapper();
        }

        public async Task<IEnumerable<DetallePerfilUsuarioDTO>> ConsultarDetallePerfil(int IDPerfil)
        {
            return mapeador.Map<IEnumerable<DetallePerfilUsuarioDTO>>(await repositorioDetalle.ConsultarPorIDPerfil(IDPerfil));
        }

        public async Task<PerfilUsuarioDTO> ConsultarPorID(int ID)
        {
            return mapeador.Map<PerfilUsuarioDTO>(await repositorioPerfil.ConsultarPorID(ID));
        }

        public async Task<IEnumerable<PerfilUsuarioDTO>> ConsultarTodos()
        {
            return mapeador.Map<IEnumerable<PerfilUsuarioDTO>>(await repositorioPerfil.ConsultarTodos());
        }

        public async Task Eliminar(int ID)
        {     
            using (var transaction = ContextoIDDVS.BeginTransaction())
            {
                IEnumerable<Usuario> usuariosAsociados = await repositorioUsuario.ConsultarPorIDPerfil(ID);

                try
                {
                    if (usuariosAsociados.Count() > 0)
                        foreach (Usuario item in usuariosAsociados)
                            await repositorioUsuario.Eliminar(item.ID);

                    IEnumerable<DetallePerfilUsuario> detalle = await repositorioDetalle.ConsultarPorIDPerfil(ID);

                    foreach (DetallePerfilUsuario item in detalle)
                        await repositorioDetalle.Eliminar(item.ID);

                    await repositorioPerfil.Eliminar(ID);

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        public async Task<bool> ExistenUsuariosAsociadoAlPerfil(int ID)
        {
            return (await repositorioUsuario.ConsultarPorIDPerfil(ID)).Count() > 0;
        }

        public async Task<PerfilUsuarioDTO> Insertar(PerfilUsuarioDTO perfil, IEnumerable<DetallePerfilUsuarioDTO> detalle)
        {
            using (var transaction = ContextoIDDVS.BeginTransaction())
            {
                var verificar = await repositorioPerfil.ConsultarPorNombre(perfil.Nombre);

                if (verificar != null)
                    throw new ArgumentException("Ya existe un perfil de usuario con ese nombre en el sistema");

                try
                {
                    var modeloPerfil = await repositorioPerfil.Insertar(mapeador.Map<PerfilUsuario>(perfil));

                    foreach (DetallePerfilUsuarioDTO item in detalle)
                    {
                        var modeloDetalle = mapeador.Map<DetallePerfilUsuario>(item);

                        modeloDetalle.PerfilUsuario = modeloPerfil;

                        await repositorioDetalle.Insertar(modeloDetalle);
                    }

                    transaction.Commit();

                    return mapeador.Map<PerfilUsuarioDTO>(modeloPerfil);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        public async Task<PerfilUsuarioDTO> Modificar(PerfilUsuarioDTO perfil, IEnumerable<DetallePerfilUsuarioDTO> detalle)
        {
            using (var transaction = ContextoIDDVS.BeginTransaction())
            {
                var verificar = await repositorioPerfil.ConsultarPorNombre(perfil.Nombre);

                if (verificar != null)
                    if (verificar.ID != perfil.ID)
                        throw new ArgumentException("Ya existe un perfil de usuario con ese nombre en el sistema");

                IEnumerable<DetallePerfilUsuario> detalleActual = await repositorioDetalle.ConsultarPorIDPerfil(perfil.ID);

                try
                {
                    foreach (DetallePerfilUsuario item in detalleActual)
                        await repositorioDetalle.EliminarPermanente(item.ID);

                    var modeloPerfil = await repositorioPerfil.Modificar(mapeador.Map<PerfilUsuario>(perfil));

                    foreach (DetallePerfilUsuarioDTO item in detalle)
                    {
                        var modeloDetalle = mapeador.Map<DetallePerfilUsuario>(item);

                        modeloDetalle.PerfilUsuario = modeloPerfil;

                        await repositorioDetalle.Insertar(modeloDetalle);
                    }

                    transaction.Commit();

                    return mapeador.Map<PerfilUsuarioDTO>(modeloPerfil);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }
    }
}
