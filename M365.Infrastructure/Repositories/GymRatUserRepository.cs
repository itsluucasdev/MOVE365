using M365.Domain.Entities;
using M365.Domain.Interfaces;
using M365.Infrastructure.Mongo;

using MongoDB.Driver;

namespace M365.Infrastructure.Repositories;

public class GymRatUserRepository(IMongoDatabase db) : MongoRepository<GymRatUserDocument>(db, "GymRatUsers"), IGymRatUserRepository;