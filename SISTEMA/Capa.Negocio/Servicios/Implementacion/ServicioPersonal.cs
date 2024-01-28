using Capa.Datos.Datos;
using Capa.Datos.Modelos;
using Capa.Datos.Repositorios;
using Capa.Datos.Repositorios.Implementaciones;
using Capa.Negocio.DTO;
using System;
using System.Threading.Tasks;

namespace Capa.Negocio.Servicios.Implementacion
{
    public class ServicioPersonal : ServicioGenerico<PersonalDTO, Personal>, IServicioPersonal
    {
        private readonly IRepositorioPersonal repositorioPersonal;
        private readonly IRepositorioIndividuo repositorioIndividuo;

        public ServicioPersonal() : base(new RepositorioPersonal())
        {
            repositorioPersonal = (IRepositorioPersonal)ObtenerRepositorio();
            repositorioIndividuo = new RepositorioIndividuo();
        }

        public async override Task Eliminar(int ID)
        {
            using (var transaction = ContextoIDDVS.BeginTransaction())
            {
                Personal modeloPersonal = await repositorioPersonal.ConsultarPorID(ID);

                if (modeloPersonal == null)
                    throw new ArgumentException("No existe el personal que esta intentando eliminar");

                try
                {
                    await repositorioPersonal.Eliminar(modeloPersonal.ID);
                    await repositorioIndividuo.Eliminar(modeloPersonal.Individuo.ID);

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        public async override Task<PersonalDTO> Modificar(PersonalDTO dto)
        {
            using (var transaction = ContextoIDDVS.BeginTransaction())
            {
                var verificar = await repositorioIndividuo.ConsultarPorDNI(dto.Individuo.DNI);

                if (verificar != null)
                    if (verificar.ID != dto.Individuo.ID)
                        throw new ArgumentException("El personal ya existe");

                try
                {
                    var modeloIndividuo = await repositorioIndividuo.Modificar(mapeador.Map<Individuo>(dto.Individuo));
                    var modeloPersonal = mapeador.Map<Personal>(dto);

                    modeloPersonal.Individuo = modeloIndividuo;

                    modeloPersonal = await repositorioPersonal.Modificar(modeloPersonal);

                    transaction.Commit();

                    return mapeador.Map<PersonalDTO>(modeloPersonal);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        public async override Task<PersonalDTO> Insertar(PersonalDTO dto)
        {
            using (var transaction = ContextoIDDVS.BeginTransaction())
            {
                var verificar = await repositorioIndividuo.ConsultarPorDNI(dto.Individuo.DNI);

                if (verificar != null)
                    throw new ArgumentException("El personal ya existe");

                try
                {
                    var modeloIndividuo = await repositorioIndividuo.Insertar(mapeador.Map<Individuo>(dto.Individuo));
                    var modeloPersonal = mapeador.Map<Personal>(dto);

                    modeloPersonal.Individuo = modeloIndividuo;

                    modeloPersonal = await repositorioPersonal.Insertar(modeloPersonal);

                    transaction.Commit();

                    return mapeador.Map<PersonalDTO>(modeloPersonal);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        public async Task<bool> ExistePersonal(string DNI)
        {
            return (await repositorioIndividuo.ConsultarPorDNI(DNI)) != null;
        }
    }
}
