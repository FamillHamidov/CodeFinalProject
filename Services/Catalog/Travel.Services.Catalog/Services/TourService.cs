using AutoMapper;
using MongoDB.Driver;
using Travel.Services.Catalog.Dtos;
using Travel.Services.Catalog.Models;
using Travel.Services.Catalog.Settings;
using Travel.Shared.Dtos;

namespace Travel.Services.Catalog.Services
{
    public class TourService:ITourService
    {
        private readonly IMongoCollection<Tour> _tourCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public TourService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _tourCollection = database.GetCollection<Tour>(databaseSettings.TourCollectionName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }
        public async Task<Response<List<TourDto>>> GetAllAsync()
        {
            var tours = await _tourCollection.Find(tour => true).ToListAsync();
            if (tours.Any())
            {
                foreach (var tour in tours)
                {
                    tour.Category = await _categoryCollection.Find(x => x.Id == tour.CategoryId).FirstAsync();
                }
            }
            else
            {
                tours = new List<Tour>();
            }
            return Response<List<TourDto>>.Success(_mapper.Map<List<TourDto>>(tours), 200);
        }

        public async Task<Response<TourDto>> GetByIdAsync(string id)
        {
            var tour = await _tourCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            if (tour==null)
            {
                return Response<TourDto>.Fail("Tour not found", 404);
            }
            tour.Category = await _categoryCollection.Find(x => x.Id == tour.CategoryId).FirstAsync();
            return Response<TourDto>.Success(_mapper.Map<TourDto>(tour), 200);
        }

        public async Task<Response<List<TourDto>>> GetByUserIdAsync(string userid)
        {
            var tours = await _tourCollection.Find<Tour>(x => x.UsserId == userid).ToListAsync();
            if (tours.Any())
            {
                foreach (var tour in tours)
                {
                    tour.Category = await _categoryCollection.Find<Category>(x => x.Id == tour.CategoryId).FirstAsync();
                }
            }
            else
            {
                tours = new List<Tour>();
            }
            return Response<List<TourDto>>.Success(_mapper.Map<List<TourDto>>(tours), 200);
        }

        public  async Task<Response<TourDto>> CreateAsync(TourCreateDto tourCreateDto)
        {
            var newTour = _mapper.Map<Tour>(tourCreateDto);
            await _tourCollection.InsertOneAsync(newTour);
            return Response<TourDto>.Success(_mapper.Map<TourDto>(newTour), 200);
        }

        public async Task<Response<NoContent>> UpdateAsync(TourUpdateDto tourUpdateDto)
        {
            var updatedTour = _mapper.Map<Tour>(tourUpdateDto);
            var result =await _tourCollection.FindOneAndReplaceAsync(x => x.Id == tourUpdateDto.Id, updatedTour);
            if (result==null)
            {
                return Response<NoContent>.Fail("Tour not found", 404);
            }
            return Response<NoContent>.Success(204);
        }

        public async Task<Response<NoContent>> DeleteAsync(string id)
        {
            var tour = await _tourCollection.DeleteOneAsync(x=>x.Id==id);
            if (tour.DeletedCount>0)
            {
                return Response<NoContent>.Success(204);
            }
            else
            {
                return Response<NoContent>.Fail("Tour not found", 404);
            }
        }
    }
}
