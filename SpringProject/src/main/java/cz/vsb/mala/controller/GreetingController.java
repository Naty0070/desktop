package cz.vsb.mala.controller;

import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
@RestController
public class GreetingController {
	@RequestMapping ("/greeting")
	String greeting() { return "Ahoj!";}
}
