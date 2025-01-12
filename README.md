Machine Status Tracker - Documentation
--------------------------------------------------

**1\. Introduction**

This document outlines the features implemented, assumptions made, and instructions for running the WPF Machine Status Tracker application.

**2\. Features Implemented**

*   **User Interface:**
    
    *   Designed a user-friendly WPF application with a modern look and feel.
        
    *   Implemented a card-style layout to display machine statuses with clear visual cues.
        
    *   Included icons to represent the operational status of each machine (e.g., green for running, yellow for idle, red for offline).
        
*   **Machine Status Management:**
    
    *   Implemented functionality to:
        
        *   **Add:** Create new machine status entries with name, description, status, and notes.
            
        *   **Edit:** Modify existing machine status entries.
            
        *   **Delete:** Remove machine status entries.
            
    *   Included basic validation to ensure that machine names are required and status values are valid.
        
*   **Filtering:**
    
    *   Implemented filtering capabilities to display machines based on their operational status.
        
*   **User Feedback:**
    
    *   Provided feedback messages to the user for successful operations (e.g., "Machine status added successfully").
        
    *   Implemented basic error handling to display informative messages to the user in case of issues.
        

**3\. Assumptions**
    
*   The application assumes that the application will be run on a Windows machine with the .NET 8.0 and above Framework installed.
    

**4\. Running the Application**

1.  **git clone**
    
2.  **Open the solution:**
    
    *   Open the solution file (.sln) in Visual Studio.
        
3.  **Build the solution:**
    
    *   Build the solution in Debug mode.
        
4.  **Run the application:**
    
    *   Press F5 to run the application in debug mode.
        
    *   Alternatively, navigate to the output directory (under the bin\\Debug folder) and run the executable (.exe) file.
            

This documentation provides a basic overview of the Machine Status Tracker application. For more detailed information, please refer to the source code and comments within the application.
