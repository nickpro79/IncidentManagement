import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Sidebar } from '../sidebar/sidebar';
import { Navbar } from '../navbar/navbar';

@Component({
  selector: 'app-app-layout',
  imports: [RouterOutlet, Sidebar, Navbar],
  templateUrl: './app-layout.html',
  styleUrl: './app-layout.css',
})
export class AppLayout {}
