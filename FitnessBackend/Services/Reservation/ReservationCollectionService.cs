using FitnessBackend.Models;
using FitnessBackend.Settings;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessBackend.Services
{
    public class ReservationCollectionService: IReservationCollectionService
    {
        private readonly IMongoCollection<Reservation> _reservation;

        public ReservationCollectionService(IMongoDBSettingsReservation settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _reservation = database.GetCollection<Reservation>(settings.ReservationCollectionName);
        }
        public async Task<bool> Create(Reservation model)
        {
            model.Id = new Guid();
            await _reservation.InsertOneAsync(model);

            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = await _reservation.DeleteOneAsync(reservation => reservation.Id == id);
            if (!result.IsAcknowledged && result.DeletedCount == 0)
            {
                return false;
            }

            return true;
        }

        public Reservation Get(Guid id)
        {
            var filter = Builders<Reservation>.Filter.Eq(f => f.Id, id);
            return _reservation.Find(filter).FirstOrDefault();
        }

        public async Task<List<Reservation>> GetAll()
        {
            var result = await _reservation.FindAsync(reservation => true);

            return result.ToList();
        }

        public List<Reservation> getReservationsByName(string name)
        {
            var filter = Builders<Reservation>.Filter.Eq(f => f.Name, name);
            return _reservation.Find(filter).ToList();
        }

        public async Task<bool> Update(Reservation model, Guid id)
        {
            model.Id = id;
            var result = await _reservation.ReplaceOneAsync(reservation => reservation.Id == id, model);
            if (!result.IsAcknowledged && result.ModifiedCount == 0)
            {
                await _reservation.InsertOneAsync(model);
                return false;
            }
            return true;
        }
    }
}
