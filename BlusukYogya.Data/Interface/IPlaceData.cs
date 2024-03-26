using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlusukYogya.Domain;

namespace BlusukYogya.Data.Interface
{
    public interface IPlaceData : ICrudData<Place>
    {
        Task<Task> AddTagToPlace(int placeId, int tagId);
        Task<IEnumerable<Place>> GetPlacesByTags(IEnumerable<int> tagIds);
    }
}
