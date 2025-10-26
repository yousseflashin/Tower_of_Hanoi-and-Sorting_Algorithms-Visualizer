# Tower of Hanoi and Sorting Algorithms Visualizer

This is a C# Windows Forms application that provides visual representations of the Tower of Hanoi puzzle and common sorting algorithms including Bubble Sort, Insertion Sort, and Selection Sort.

## Features

- **Tower of Hanoi Visualizer**: Interactive visualization of the classic Tower of Hanoi problem with adjustable speed controls.
- **Sorting Algorithms Visualizer**: Step-by-step visualization of Bubble Sort, Insertion Sort, and Selection Sort.
- **Speed Controls**: Adjust the animation speed from slow to instant for better understanding.
- **User Input**: Enter the number of disks for Tower of Hanoi or array elements for sorting.
- **Reset Functionality**: Reset the visualization to start over.

## Requirements

- .NET Framework 4.7.2 or higher
- Windows operating system

## How to Run

1. Clone or download the repository.
2. Open the solution file (`visulizare_project.csproj`) in Visual Studio.
3. Build the project.
4. Run the application.
5. Select the desired algorithm from the main menu and follow the on-screen instructions.

## Project Structure

- `Form1.cs`: Main menu form.
- `Hanoi.cs`: Tower of Hanoi visualization form.
- `bubble_sort.cs`: Bubble Sort visualization form.
- `insertion_sort.cs`: Insertion Sort visualization form.
- `selction_sort.cs`: Selection Sort visualization form (note: filename has a typo, should be selection_sort.cs).
- Other files: Designer and resource files for the forms.

## Usage

- Launch the application to see the main menu.
- Choose between Tower of Hanoi or one of the sorting algorithms.
- For Tower of Hanoi: Enter the number of disks (1-10) and click "compile" to start the visualization.
- For Sorting: Enter a list of numbers separated by spaces and click "compile" to visualize the sort.
- Use the speed radio buttons to control the animation pace.
- Click "rest" to reset the visualization.

## Contributing

Feel free to contribute improvements or additional sorting algorithms.