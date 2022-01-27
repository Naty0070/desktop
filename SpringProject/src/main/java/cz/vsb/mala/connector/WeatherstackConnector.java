package cz.vsb.mala.connector;

import java.net.URI;
import java.net.URISyntaxException;

import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.client.RestTemplate;

import cz.vsb.mala.dto.WeatherDto;
import cz.vsb.mala.dto.WeatherstackDto;

public class WeatherstackConnector {
	private static String baseUrl="http://api.weatherstack.com/";
	private static String urlParams="current?access_key=";
	private static String apiKey="Wont tell you :D!";
	private static String url = baseUrl+urlParams+apiKey+"&query=";

	public WeatherstackDto getWeatherForCity(City cityEnum)   
		{RestTemplate template=new RestTemplate();
		URI uri=null;
		try {
			uri = new URI(getUrl()+cityEnum);
		} catch (URISyntaxException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		ResponseEntity<WeatherstackDto> response=template.getForEntity(uri, WeatherstackDto.class);
	
		return response.getBody();}
	
	public static String getUrl() {
		return url;
	}

	public static void setUrl(String url) {
		WeatherstackConnector.url = url;
	}

	
}
