package cz.vsb.mala.service;

import java.net.URI;
import java.net.URISyntaxException;

import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;
import org.springframework.web.client.RestTemplate;

import cz.vsb.mala.connector.City;
import cz.vsb.mala.connector.WeatherstackConnector;
import cz.vsb.mala.dto.WeatherDto;
import cz.vsb.mala.dto.WeatherstackDto;
@Service
public class WeatherService {
	public WeatherDto getWeatherForCity(City cityEnum) {
    	WeatherstackConnector connector = new WeatherstackConnector ();
    	WeatherstackDto weatherStackDto = connector.getWeatherForCity(cityEnum);
    	return transformDto(weatherStackDto);

	}
	private WeatherDto transformDto(WeatherstackDto weatherStackDto) {
	  	WeatherDto wdto = new WeatherDto();
	  	wdto.setLocation(weatherStackDto.getLocation().getName());
	  	wdto.setRel_humidity(weatherStackDto.getCurrent().getHumidity());
	  	wdto.setTimestamp(weatherStackDto.getCurrent().getObservation_time());
	  	wdto.setTemp_celsius(weatherStackDto.getCurrent().getTemperature());
	  	wdto.setTimestamp(weatherStackDto.getCurrent().getObservation_time());
	  	wdto.setWeatherDescription(weatherStackDto.getCurrent().getWeather_descriptions());
	  	wdto.setWindDirection(weatherStackDto.getCurrent().getWind_dir());
	  	wdto.setWindSpeed_mps(weatherStackDto.getCurrent().getWind_speed());
	  	return wdto;
	}
}
