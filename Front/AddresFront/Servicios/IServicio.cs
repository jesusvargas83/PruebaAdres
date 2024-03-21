using AddresFront.Models;

namespace AddresFront.Servicios
{
    public interface IServicio
    {
        Task <List<Adquisicion>> Lista();
        Task <List<Historial>> Historial();
        Task<Adquisicion> Obtener(int id);
        Task<bool> Guardar(Adquisicion objeto);
        Task<bool> Editar(Adquisicion objeto);
        Task<bool> Eliminar(int id);


    }
}
