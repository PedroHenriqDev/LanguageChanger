![Icon](https://github.com/PedroHenriqDev/LanguageChanger/blob/master/LanguageChanger/Images/Language_Changer.jpg.jpg) 
# Language Changer
## A package for managing multilingual messages in your program

The **LanguageChanger** is a package designed to simplify the management of messages in different languages in software projects, promoting an efficient and structured approach.

---

## How to Use LanguageChanger?

The recommended way to use LanguageChanger involves creating a dedicated directory in your project, with a name of your choice. Inside this directory, organize the messages into subfolders, separating files by language. Each subfolder should contain JSON files representing different message contexts.

### Example Structure:
```text
Languages
├── English
│   └── Main.json
└── Portuguese
    └── Index.json
```
### ``Language management`` is based on two main objects with specific roles: ``LanguageTrackerConfig`` and ``LanguageTracker``.
- `LanguageTrackerConfig`: This object centralizes configuration settings, including default values for directory paths, default language, and default file names. It is designed with optional parameters, allowing you to define a base directory, default language, and a default file name for searches.

- `LanguageTracker`: The core object of the LanguageChanger, it leverages the settings in LanguageTrackerConfig to provide highly efficient message retrieval methods. The constructor of LanguageTracker requires an instance of LanguageTrackerConfig. Using these configurations, the LanguageTracker offers two primary methods:

- `GetText`: Retrieves a specific message by its key, using the previously defined structure.

- `GetTexts`: Retrieves all keys and values from a specified section in a JSON file, returning them as a dictionary.

### Scenario with All Restrictions Defined in `LanguageTrackerConfig`
```Csharp
  LanguageTrackerConfig Config = new LanguageTrakerConfig("Languages", "French", "Index");
  ILanguageTracker LanguageTracker = new LanguageTracker(Config);
```

### Scenario Without Optional Parameters in `LanguageTrackerConfig` If no optional parameters are provided when creating an instance of `LanguageTrackerConfig`, the following default values will be used:
1. `BaseDirectory`: "Languages"
2. `DefaultLanguage`: "English"
3. `FileNameDefault`: "Main"
```Csharp
  LanguageTrackerConfig config = new LanguageTrakerConfig();
  ILanguageTracker languageTracker = new LanguageTracker(config);
```

## `GetText`
### The `GetText` method requires one mandatory parameter: the key corresponding to the message value in the JSON file. The other parameters are optional. If these optional parameters are not provided, the method will use the default values defined in the LanguageTracker instance. When all parameters are specified, they include:
1. `Key` (Required): The key where the message value is located in the JSON.
2. `FileName` (Optional): The JSON file name (extension is not required but will work if included).
3. `Language` (Optional): The language folder to be used.
### The method returns a string containing the message value defined under the specified key in the JSON file.
```Csharp
  // Assuming an instance of LanguageTracker is already configured.
  string message = languageTracker.GetText("Title", "Index", "English");
  // The variable `message` will hold the value: "Example Title".
```
```Csharp
    string message = languageTracker.GetText("Title");
  // The search uses the default file name and language from the configuration.
```
## Example of File Contents `index.json`:
```JSON
{
  "Title": "Example Title",
  "Presentations": {
    "Morning": "Hello, Good Morning.",
    "Night": "Hello, Good Night."
   }
}
```
## `GetTexts` 
The `GetTexts` method retrieves all key-value pairs from a specific section in a JSON file and returns them as a dictionary. It requires one mandatory parameter: the section name, which must correspond to a section in the specified JSON file. The other parameters are optional. If these are not provided, the method will use the default values configured in the `LanguageTrackerConfig`. Parameters:
1. `Section` (Required): The name of the section in the JSON file.
2. `FileName` (Optional): The JSON file name (extension is not required but will work if included).
3. `Language` (Optional): The language folder to be used.
Return Value: The method returns a dictionary where each key-value pair corresponds to the keys and values in the specified section of the JSON file.

Example Usage:

``` csharp
// Retrieve all key-value pairs from the "Presentations" section in the "Index" JSON file in the "English" folder.
Dictionary<string, string?> presentationsDict = languageTracker.GetTexts("Presentations", "Index", "English");

// Access a specific key-value pair (e.g., the "Morning" greeting).
KeyValuePair<string, string?> presentationKeyValuePair = presentationsDict.FirstOrDefault(p => p.Key == "Morning");
string presentationMorning = presentationKeyValuePair.Value;

// The value of "presentationMorning" will be: "Hello, Good Morning."
```
---
## This package was developed independently, and new ideas are welcome! Suggestions that align with the purpose of the LanguageChanger may be evaluated and added in future updates.
