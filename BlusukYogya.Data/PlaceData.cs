using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlusukYogya.Data.Interface;
using BlusukYogya.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlusukYogya.Data
{
    public class PlaceData : IPlaceData
    {
        private readonly YogyaBlusukContext _context;
        public PlaceData(YogyaBlusukContext yogyaBlusukContext)
        {
            _context = yogyaBlusukContext;
        }

        public async Task<Task> AddTagToPlace(int placeId, int tagId)
        {
            try
            {
                var tag = await _context.Tags.SingleOrDefaultAsync(c => c.TagId == tagId);
                var place = await _context.Places.FindAsync(placeId);

          
                if (tag.CategoryId == place.CategoryType)
                {
                    place.Tags.Add(tag);
                    await _context.SaveChangesAsync();
                    return Task.CompletedTask;
                }else
                {
                    throw new ArgumentException("CategoryID tidak sama");
                }
                
                
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Penambahan tidak Berhasil");
            }
        }

        public async Task Create(Place entity)
        {
            await _context.Places.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var place = await _context.Places.FindAsync(id);
            _context.Places.Remove(place);
            await _context.SaveChangesAsync();
        }

        public async Task<Place> Get(int id)
        {
            var data = await _context.Places.FindAsync(id);
            return data;
        }

        public async Task<IEnumerable<Place>> GetAll()
        {
            List<Place> allData = await _context.Places.ToListAsync();
            return allData;
        }

        public async Task<IEnumerable<Place>> GetPlacesByTags(IEnumerable<int> tagIds )
        {
            List<Place> allData = await _context.Places
    .Where(place => tagIds.All(tagId => place.Tags.Any(tag => tag.TagId == tagId)))
    .ToListAsync();

            return allData;
        }

        public async Task Update(Place entity)
        {
            var Place = await _context.Places.FindAsync(entity.PlaceId);
            Place.Name = entity.Name;
            Place.Description = entity.Description;
            Place.Location = entity.Location;
            Place.Rating = entity.Rating;
            Place.AveragePrice = entity.AveragePrice;
            await _context.SaveChangesAsync();
        }
    }
}
