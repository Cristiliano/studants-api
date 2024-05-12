using Student.Application.Interfaces;
using Student.Application.Models.InputModels;
using Student.Domain.Entities;

namespace Student.Infraestructure.Repositories
{
    public class NotaRepository : INotaRepository
    {
        private List<NotaEntity> notaEntities = new List<NotaEntity>()
        {
            new NotaEntity()
            {
                iCodMateria = 1,
                iCodAluno = 1,
                iCodNota = 1,
                nNota = 10
            }
        };

        public NotaRepository() { }

        public int Add(NotaInputModel model)
        {
            var rand = new Random();
            int ID = rand.Next(2, 1000);
            var entity = new NotaEntity
            {
                iCodNota = ID,
                iCodAluno = model.iCodAluno,
                iCodMateria = model.iCodMateria,
                nNota = model.nNota,
            };

            notaEntities.Add(entity);
            return entity.iCodMateria;
        }

        public NotaEntity? GetById(int id)
        {
            return notaEntities.Find(m => m.iCodMateria == id);
        }

        public List<NotaEntity?> GetAll()
        {
            return notaEntities;
        }

        public NotaEntity? Update(NotaInputModel nota, int id)
        {
            var notaFind = GetById(id);

            if (notaFind is null)
            {
                return null;
            }

            foreach (var n in notaEntities.Where(n => n.iCodNota == id))
            {
                n.iCodAluno = nota.iCodAluno;
                n.iCodMateria = nota.iCodMateria;
                n.nNota = nota.nNota;
            }

            return notaEntities.Where(n => n.iCodNota == id).FirstOrDefault();
        }

        public bool Delete(int id)
        {
            var notaFind = GetById(id);

            if (notaFind is null)
            {
                return false;
            }

            notaEntities.Remove(notaFind);

            return true;
        }
    }
}
