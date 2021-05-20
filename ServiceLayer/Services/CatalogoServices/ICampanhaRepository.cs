using DomainLayer.Models.Catalogos;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.CatalogoServices
{
    public interface ICampanhaRepository
    {
        CampanhaModel Add(ICampanhaModel campanhaModel);
        void Update(ICampanhaModel campanhaModel);
        void Delete(ICampanhaModel campanhaModel);
        IEnumerable<ICampanhaModel> GetAll();
        IEnumerable<ICampanhaModel> GetByCatalogoId(int catalogoId);
        CampanhaModel GetById(int campanhaId);
    }
}
