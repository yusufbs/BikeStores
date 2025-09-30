import { Component, ViewChild } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-html-to-docx',
  imports: [FormsModule],
  templateUrl: './html-to-docx.html',
  styleUrl: './html-to-docx.css',
})
export class HtmlToDocx {
  inputValue: string = ''; // Initialize the property for the text box value

  // @ViewChild() childComponent!; // Example of using ViewChild if needed later

  submitText() {
    // This method will be called when the button is clicked
    console.log('Text submitted:', this.inputValue);
    // You can add further logic here, e.g., send the value to a service, update other parts of the UI, etc.
    alert('You entered: ' + this.inputValue); // Example: Display an alert with the entered text
    this.inputValue = ''; // Optionally clear the input field after submission
  }
}
