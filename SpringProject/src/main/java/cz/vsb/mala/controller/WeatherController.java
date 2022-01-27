package cz.vsb.mala.controller;

import java.util.ArrayList;
import java.util.Collection;
import java.util.List;

import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.PathVariable;


import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import cz.vsb.mala.connector.*;
import cz.vsb.mala.dto.*;
import cz.vsb.mala.service.WeatherService;

@RestController

public class WeatherController {
	@RequestMapping ("/weather")
	public Collection<WeatherDto> getWeather(){
		List<WeatherDto> weatherDtos=new ArrayList<>();
		WeatherService weatherService=new WeatherService();
		for(City city:City.values()) {
			WeatherDto wdWeatherDto=weatherService.getWeatherForCity(city);
			weatherDtos.add(wdWeatherDto);
		}
		return weatherDtos;
			
		}

	@CrossOrigin
	@RequestMapping ("/weather/{city}")
	public WeatherDto getWeatherForCity(@PathVariable String city) { 
		City cityEnum=City.valueOf(city.toUpperCase());
		WeatherService weatherService=new WeatherService();
		return weatherService.getWeatherForCity(cityEnum);
}
	@RequestMapping("/weather/bruntal")
	public String bruntal() {
		return "<html><body><h1>CHYBA! BRUNTÁL NEBYL LOKALIZOVÁN!</h1>"
				+ "Mlha... všude mlha... a migrující žáby. <br>"
				+ "<img src= 'http://www.zubatezaby.cz/files/IMG_26.jpg'/>"
				+ "</body></html>";
	}
}
