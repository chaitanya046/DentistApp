# DentistApp

## Description
This project is built to reflect what a dental clinic's appointments and patients management system would be like.

## Project Structure
This project is a Windows Presentation Foundation Application. Wpf application has a reference project (console appplication) where hosts business logic classes.

## Scenario
The clinic has two doctors, a General Dentist & a Pediatric Dentist. Both have their seperate calendars. Our clinic has only one dental chair. So appointments should be booked in a systematic way via WPF application. The clinic has a admissions clerk, responsible for managing the appointments and filling the patiens' information.

## WPF User Interface
- Current Day+1 (Show Tomorrows date)
- Available Appointment Slots ->Combobox-> Starts from 9AM to 4PM with 1 hour intervals. Total 8 slots.
- Gender ->Combobox-> Male, Female, Other
- Age ->Textbox-> 
      ->Age <=15 Create Child Customer
      ->Age >15  Create Adult Customer
- Medical Conditions->Combobox->Yes or No (or Diabetes||HepatitB||None)
- CT-XRAY->Combobox->Yes or No
- Treatment->Combobox-> Filling,Extraction, Root Canal Treatment, Bleaching, Polishing, Orthodontic Treatment, Dentures, Implant
- Payment Method->Combobox->Insurance Coverage, OHIP Coverage, Cash/Debit/CreditCard
- Contact Number->Textbox
- CreditCard->Textbox
- Add Button-> Adds patient to data grid
- Save Button-> Saves patients to XML file.
- Display Button-> Display all patients in data grid.
- LINQ Query ->Search Button and Textbox->...will determine the query

##  Functions
After filling patient's information, the child customer or adult customer is created according the age rule.
While displaying all patients in data grid, patients who are children is shown in green and patients who has medical conditions is hown in red.(Row converter)


## Additional notes
Do we really need this functions?
- Update Button-> Reads XML file, fetches all patients list. After selecting a patient sets related patient's info to left panel. Enables updating patient's information.
- Delete Button-> Reads XML file, fetches all patients list. Enables deleting a patient after selecting it.

