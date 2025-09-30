import { Component } from '@angular/core';
import { HtmlToDocx } from '../html-to-docx/html-to-docx';

@Component({
  selector: 'app-resume',
  imports: [HtmlToDocx],
  templateUrl: './resume.html',
  styleUrl: './resume.css',
})
export class Resume {}
