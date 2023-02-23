using HotelBooking.DAL.Configurations;
using HotelBooking.DAL.IRepositories;
using HotelBooking.Domain.Common;
using HotelBooking.Domain.Entities;
using Newtonsoft.Json;
using System.Reflection;

namespace HotelBooking.DAL.Repositories;


public class GenericRepository<TResult> : IGenericRepository<TResult> where TResult : Auditable
{
    public readonly string path;
    public long LastId;

    public GenericRepository()
    {
        if (typeof(TResult) == typeof(Amenity))
        {
            path = DatabasePath.AMENITY_PATH;
        }
        else if (typeof(TResult) == typeof(Hotel))
        {
            path = DatabasePath.HOTEL_PATH;
        }
        else if (typeof(TResult) == typeof(Reservation))
        {
            path = DatabasePath.RESERVATION_PATH;
        }
        else if (typeof(TResult) == typeof(Room))
        {
            path = DatabasePath.ROOM_PATH;
        }
        else if (typeof(TResult) == typeof(RoomsAmenity))
        {
            path = DatabasePath.ROOMS_AMENTITY_PATH;
        }
        else if (typeof(TResult) == typeof(User))
        {
            path = DatabasePath.USER_PATH;
        }
    }

    public async Task<TResult> CreateAsync(TResult value)
    {
        value.Id = ++LastId;
        var models = await GetAllAsync();
        models.Add(value);

        File.WriteAllText(path, JsonConvert.SerializeObject(models, Formatting.Indented));

        return value;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var models = await GetAllAsync();
        var model = models.FirstOrDefault(x => x.Id == id);
        if (model is null)
        {
            return false;
        }
        models.Remove(model);
        var json = JsonConvert.SerializeObject(models, Formatting.Indented);
        await File.WriteAllTextAsync(path, json);
        return true;
    }

    

    public async Task<List<TResult>> GetAllAsync(Predicate<TResult> predicate = null)
    {
        var models = await File.ReadAllTextAsync(path);
        if (string.IsNullOrEmpty(models))
            models = "[]";

        var result = JsonConvert.DeserializeObject<List<TResult>>(models);

        if (predicate is null)
            return result;

        return result.FindAll(predicate);


    }

    public async Task<TResult> GetByIdAsync(long id)
    {
        var models = await GetAllAsync();
        var model = models.FirstOrDefault(x => x.Id == id);
        return model;
    }


    public async Task<TResult> UpdateAsync(TResult value)
    {
        var models = await GetAllAsync();
        var updatingModel = models.FirstOrDefault(x => x.Id == value.Id);

        if (updatingModel == null)
            return null;

        int index = models.IndexOf(updatingModel);

        models.Remove(updatingModel);

        value.CreatedAt = updatingModel.CreatedAt;
        models.Insert(index, value);

        File.WriteAllText(path, JsonConvert.SerializeObject(models, Formatting.Indented));

        return value;
    }
}






