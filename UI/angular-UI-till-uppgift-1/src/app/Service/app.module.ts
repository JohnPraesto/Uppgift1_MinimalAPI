import{FormsModule, NgModel}from "@angular/forms"
import{AppComponent} from "../app.component"
import{NgModule} from "@angular/core"
import { BrowserModule } from "@angular/platform-browser"
import { HttpClientModule } from "@angular/common/http"
import { HttpClient } from "@angular/common/http"

@NgModule({
    imports:[
        BrowserModule,
        FormsModule,
        HttpClientModule
    ]
}) export class AppModule{}