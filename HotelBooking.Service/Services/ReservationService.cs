using HotelBooking.DAL.IRepositories;
using HotelBooking.DAL.Repositories;
using HotelBooking.Domain.Entities;
using HotelBooking.Service.Helpers;
using HotelBooking.Service.Interfaces;

namespace HotelBooking.Service.Services;

public class ReservationService : IReservationService
{
    private readonly IGenericRepository<Reservation> reservationRepository;
    public ReservationService()
    {
        reservationRepository = new GenericRepository<Reservation>();
    }
    public async Task<GenericResponse<Reservation>> CreateAsync(Reservation reservation)
    {
        var models = await this.reservationRepository.GetAllAsync();
        var model = models.FirstOrDefault(x => x.FirstName == reservation.FirstName);

        if (model is not null)
        {
            return new GenericResponse<Reservation>
            {
                StatusCode = 404,
                Message = "This category is already exists",
                Value = null,
            };
        }
        var mappedModel = new Reservation()
        {
            Id= reservation.Id,
            FirstName = reservation.FirstName,
            LastName = reservation.LastName,
            Note= reservation.Note,
            Payment = reservation.Payment,
            PaymentType= reservation.PaymentType,
            Status= reservation.Status,
            ChackIn = reservation.ChackIn,
            ChackOut= reservation.ChackOut,
            CreatedAt = DateTime.UtcNow,
        };
        await reservationRepository.CreateAsync(mappedModel);

        return new GenericResponse<Reservation>
        {
            StatusCode = 200,
            Message = "New category created",
            Value = mappedModel
        };
    }

    public async Task<GenericResponse<Reservation>> DeleteAsync(long id)
    {
        var model = await this.reservationRepository.GetByIdAsync(id);
        if (model is null)
        {
            return new GenericResponse<Reservation>
            {
                StatusCode = 404,
                Message = "Not found",
                Value = null
            };
        }
        await this.reservationRepository.DeleteAsync(model.Id);

        return new GenericResponse<Reservation>
        {
            StatusCode = 200,
            Message = "Successfully deleted )",
            Value = model,
        };
    }

    public async Task<GenericResponse<List<Reservation>>> GetAllAsync(Predicate<Reservation> predicate)
    {
        var models = await reservationRepository.GetAllAsync(predicate);
        if (models is null)
        {
            return new GenericResponse<List<Reservation>>
            {
                StatusCode = 404,
                Message = "Empty",
                Value = null,
            };
        }
        return new GenericResponse<List<Reservation>>
        {
            StatusCode = 200,
            Message = "Ok )",
            Value = models
        };
    }

    public async Task<GenericResponse<Reservation>> GetByIdAsync(long id)
    {
        var model = await this.reservationRepository.GetByIdAsync(id);

        if (model is null)
        {
            return new GenericResponse<Reservation>
            {
                StatusCode = 404,
                Message = "Not found",
                Value = null,
            };
        }
        return new GenericResponse<Reservation>
        {
            StatusCode = 200,
            Message = "Ok )",
            Value = model,

        };
    }

    public async Task<GenericResponse<Reservation>> UpdateAsync(long id, Reservation reservation)
    {
        var model = await this.reservationRepository.GetByIdAsync(id);

        if (model is null)
        {
            return new GenericResponse<Reservation>
            {
                StatusCode = 404,
                Message = "Not found",
                Value = null,
            };
        }

        var mappedmodel = new Reservation()
        {
            CreatedAt = reservation.CreatedAt,
            UpdatedAt = DateTime.UtcNow,
            FirstName = reservation.FirstName,
            LastName = reservation.LastName,
            Note = reservation.Note,
            Payment = reservation.Payment,
            PaymentType = reservation.PaymentType,
            Status = reservation.Status,
            ChackIn = reservation.ChackIn,
            ChackOut = reservation.ChackOut,
            Id= reservation.Id,
        };
            
        var res = await this.reservationRepository.UpdateAsync(mappedmodel);

        return new GenericResponse<Reservation>
        {
            StatusCode = 200,
            Message = "Successfully updated )",
            Value = mappedmodel,
        };
            
    }
}
            




