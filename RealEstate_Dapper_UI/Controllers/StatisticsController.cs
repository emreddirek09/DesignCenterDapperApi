﻿using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_UI.Models;

namespace RealEstate_Dapper_UI.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        private string _titleUrl = @"https://localhost:44319/api/Statistics/";

        public StatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {

            StatisticResponseValueName _name = new StatisticResponseValueName();
            StatisticResponseValue _valueName = new StatisticResponseValue();

            var client = _httpClientFactory.CreateClient();

            for (int i = 0; i < _name.namesEng.Count(); i++)
            {
                var response = await client.GetAsync(_titleUrl + _name.namesEng[i]);
                var jsonData = await response.Content.ReadAsStringAsync();
                _valueName.pairs.Add(_name.namesTr[i], jsonData);
            }

            return View(_valueName);
        }
    }
}
