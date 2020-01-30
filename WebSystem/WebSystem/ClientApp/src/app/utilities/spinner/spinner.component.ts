import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-spinner',
  templateUrl: './spinner.component.html',
  styleUrls: ['./spinner.component.css']
})
export class SpinnerComponent implements OnInit {

  constructor() { }

  ngOnInit() {
    //this.animateSpinner();
  }

  //animateSpinner() {
  //  let cA = document.getElementById('cA');
  //  let cB = document.getElementById('cB');
  //  let cC = document.getElementById('cC');

  //  setTimeout(() => {
  //    cA.style.animationName = "cAnimate ";
  //    cC.style.animationName = "cCnimate ";

  //    cA.style.transform = "translateY(0px)";
  //    cC.style.transform = "translateY(0px)";
  //  }, 300)
  //  setTimeout(() => {
  //    cB.style.animationName = 'cBnimate';
  //    cB.style.transform = 'translateX(-40px)';
  //  },400)

  //}


}
