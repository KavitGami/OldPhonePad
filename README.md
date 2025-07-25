# 📞 OldPhonePad Decoder

This is a C# console application that decodes input strings from an **old-school mobile phone keypad**, simulating the multi-tap input method.

For example:
```
Input: 4433555 555666#
Output: HELLO
```

It supports:
- Multi-tap letter selection
- Backspace (`*`)
- Word breaks (` ` as pause)
- Send key (`#`) to finalize input

---

## 📦 Project Structure

```
OldPhonePad/
├── OldPhonePad/            # Main application logic
│   ├── PhonePad.cs         # Core decoding logic
│   ├── Program.cs          # Console runner
│   └── OldPhonePad.csproj
├── OldPhonePad.Tests/      # Unit test project using xUnit
│   ├── OldPhonePadTests.cs
│   └── OldPhonePad.Tests.csproj
├── OldPhonePad.sln         # Solution file
└── README.md               # This file
```

---

## 🚀 How to Run

### 1. Clone the repository
```bash
git clone https://github.com/your-username/OldPhonePad.git
cd OldPhonePad
```

### 2. Build the project
```bash
dotnet restore
dotnet build
```

### 3. Run the app
```bash
dotnet run --project OldPhonePad
```

You will be prompted for input:
```
Enter input for OldPhonePad (end with #):
4433555 555666#
Output: HELLO
```

---

## 🧪 Run Tests

Unit tests are written with **xUnit** and cover multiple input cases:

```bash
dotnet test
```

You should see something like:
```
Total tests: 9. Passed: 9. Failed: 0. Skipped: 0.
```

---

## 📚 Sample Inputs

| Input                      | Output  |
|---------------------------|---------|
| `33#`                     | `E`     |
| `227*#`                   | `B`     |
| `8 88777444666*664#`      | `TURING`|
| `222 2 22#`               | `CAB`   |
| `1#`                      | `&`     |
| `0#`                      | ` `     |

---

## 🛠 Tech Stack

- C# 12
- .NET 8
- xUnit for unit testing

---

## ✍️ Author

Built by [Kavit Gami](https://github.com/kavitgami)
