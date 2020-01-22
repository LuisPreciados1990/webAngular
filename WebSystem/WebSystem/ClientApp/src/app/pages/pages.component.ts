import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-pages',
  templateUrl: './pages.component.html',
  styleUrls: ['./pages.component.css']
})
export class PagesComponent implements OnInit {
  
  navLinks: any[];
  activeLinkIndex = -1;
  constructor(private router: Router) {
    this.navLinks = [
      {
        label: 'First',
        link: '/web01f110',
        index: 0
      }, {
        label: 'Second',
        link: '/web01f120',
        index: 1
      }, {
        label: 'Third',
        link: '/web01f130',
        index: 2
      },
    ];
  }
  ngOnInit(): void {
    //this.router.events.subscribe((res) => {
    //  this.activeLinkIndex = this.navLinks.indexOf(this.navLinks.find(tab => tab.link === this.router.url));      
    //});
  }
}
