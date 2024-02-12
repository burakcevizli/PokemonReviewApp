﻿using AutoMapper;
using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
	public class CountryRepository : ICountryRepository
	{
		private readonly DataContext _context;
		private readonly IMapper _mapper;

		public CountryRepository(DataContext context,IMapper mapper)
        {
			_context = context;
			_mapper = mapper;
		}
        public bool CountryExist(int id)
		{
			return _context.Countires.Any(c=>c.Id == id);
		}

		public ICollection<Country> GetCountries()
		{
			return _context.Countires.ToList();
		}

		public Country GetCountry(int id)
		{
			return _context.Countires.Where(c => c.Id == id).FirstOrDefault();
		}

		public Country GetCountryByOwner(int ownerId)
		{
			return _context.Owners.Where(o => o.Id == ownerId).Select(c => c.Country).FirstOrDefault();
		}

		public ICollection<Owner> GetOwnersFromACountry(int countryId)
		{
			return _context.Owners.Where(c => c.Country.Id == countryId).ToList();
		}
	}
}
