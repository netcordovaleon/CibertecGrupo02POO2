import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  public forecasts?: WeatherForecast[];

  mensaje: string = "";
  tipoFormato: string = "";

  constructor(http: HttpClient) {

    http.get<WeatherForecast[]>('/weatherforecast').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));


    http.get<any>('/api/Student').subscribe(result => {

      console.log(result);
      this.mensaje = result.mensaje;
      this.tipoFormato = result.tipoFormato;

    }, error => console.error(error));

  }

  title = 'angularapp';

}

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
