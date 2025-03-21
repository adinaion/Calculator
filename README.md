# 💻 Calculator Application

**Calculator** is a **WPF-based application** built with **C#**, implementing features from both the **Standard** and partially from the **Programmer** modes of the Windows Calculator application. It provides a variety of operations and functionalities to facilitate calculations in different modes.

## ➕ Features

- **Basic Arithmetic Operations**:
  - Addition, subtraction, multiplication, division, percentage, square root, square, plus/minus toggle, reciprocal.

- **Memory Operations**:
  - **Backspace**: Deletes one character on the display.
  - **CE**: Clears the last number entered and resets the display value to 0.
  - **C**: Clears the entire current operation.
  - **M+**: Adds the current display value to memory.
  - **M-**: Subtracts the current display value from memory.
  - **MS**: Stores the current display value in memory.
  - **MR**: Displays the value stored in memory.
  - **M>**: Displays the memory stack, allowing usage of any stored value in further operations.

- **Cut/Copy/Paste Operations**: 
  - Implemented manually using strings, without relying on the default copy/paste operations available for text controls.

- **Digit Grouping**:
  - Groups digits in thousands, adjusting to the user's locale settings (e.g., `1.000` for Romanian and `1,000` for UK settings).
  
- **Base Conversion (Programmer Mode)**:
  - Allows conversion and display of numbers in binary, octal, decimal, and hexadecimal, while maintaining internal calculations in base 10.

- **Help Menu**:
  - A "Help" menu with an "About" submenu displaying the developer's name.

## 🛠️ Technologies Used

- **C#** (WPF application for the UI)
- **.NET Framework** (for application functionality)
- **XAML** (for UI design)
- **CultureInfo** (for handling locale-specific number formatting)
