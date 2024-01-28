using AutoMapper;
using Capa.Datos.Modelos;
using Capa.Datos.Repositorios;
using Capa.Negocio.DTO;
using Capa.Negocio.Mapeo;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Capa.Negocio.Servicios.Implementacion
{
    public abstract class ServicioGenerico<DTO, Modelo> : IServicioGenerico<DTO> where DTO : class, IDTO where Modelo : class, IModelo
    {
        protected readonly IMapper mapeador;
        private IRepositorioGenerico<Modelo> repositorio;

        public ServicioGenerico(IRepositorioGenerico<Modelo> repositorio)
        {
            this.repositorio = repositorio;
            this.mapeador = MapperConfig.GetInstance().CreateMapper();
        }

        protected ref IRepositorioGenerico<Modelo> ObtenerRepositorio()
        {
            return ref repositorio;
        }

        public virtual async Task<DTO> ConsultarPorID(int ID)
        {
            return mapeador.Map<DTO>(await repositorio.ConsultarPorID(ID));
        }

        public virtual async Task<IEnumerable<DTO>> ConsultarTodos()
        {
            return mapeador.Map<IEnumerable<DTO>>(await repositorio.ConsultarTodos());
        }

        public virtual async Task Eliminar(int ID)
        {
           await repositorio.Eliminar(ID);
        }

        public virtual async Task<DTO> Insertar(DTO dto)
        {
           return mapeador.Map<DTO>(await repositorio.Insertar(mapeador.Map<Modelo>(dto)));
        }

        public virtual async Task<DTO> Modificar(DTO dto)
        {
            return mapeador.Map<DTO>(await repositorio.Modificar(mapeador.Map<Modelo>(dto)));
        }
    }
}
