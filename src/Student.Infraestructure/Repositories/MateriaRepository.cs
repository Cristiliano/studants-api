using Student.Application.Interfaces;
using Student.Application.Models.InputModels;
using Student.Domain.Entities;

namespace Student.Infraestructure.Repositories
{
    public class MateriaRepository : IMateriaRepository
    {
        private List<MateriaEntity> materiaEntities = new List<MateriaEntity>()
        {
            new MateriaEntity()
            {
                iCodMateria = 1,
                sDescricao = "Matematica"
            }
        };

        public MateriaRepository() { }

        public int Add(MateriaInputModel model)
        {
            var rand = new Random();
            int ID = rand.Next(2, 1000);
            var entity = new MateriaEntity
            {
                iCodMateria = ID,
                sDescricao = model.sDescricao
            };

            materiaEntities.Add(entity);
            return entity.iCodMateria;
        }

        public MateriaEntity? GetById(int id)
        {
            return materiaEntities.Find(m => m.iCodMateria == id);
        }

        public List<MateriaEntity?> GetAll()
        {
            return materiaEntities;
        }

        public MateriaEntity? Update(MateriaInputModel materia, int id)
        {
            var materiaFind = GetById(id);

            if (materiaFind is null)
            {
                return null;
            }

            foreach (var m in materiaEntities.Where(m => m.iCodMateria == id))
            {
                m.sDescricao = materia.sDescricao;
            }

            return materiaEntities.Where(m => m.iCodMateria == id).FirstOrDefault();
        }

        public bool Delete(int id)
        {
            var materiaFind = GetById(id);

            if (materiaFind is null)
            {
                return false;
            }

            materiaEntities.Remove(materiaFind);

            return true;
        }
    }
}
