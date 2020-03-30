# ComplementDrugSearch

## Table of contents

* [Introduction](#introduction)
* [Download](#download)
* [Usage](#usage)
  * [Help](#help)
  * [Drug](#drug)
  * [Proteins](#proteins)

## Introduction

Welcome to the ComplementDrugSearch repository!

This is a C# / .Net Core application which aims to identify possible drugs that complement a given drug acting on a directed protein-protein interaction network. The application is cross-platform, working on all modern operating systems (Windows, MacOS, Linux) and can be run through CLI (command-line interface).

## Download

The repository consists of a Visual Studio 2019 project. You can download it to run or build the application yourself. You need to have [.NET Core 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1) installed on your computer in order to run it, or the corresponding SDK in order to also be able to build it.

## Usage

Open your operating system's terminal or console and navigate to the `ComplementDrugSearch` folder (the one containing the file `Program.cs`). There, you can run the application with:

```
dotnet run
```

### Help

In order to find out more about the usage and possible arguments which can be used, you can launch the application with the `--Mode` argument set to `Help` (or omit it entirely), for example:

```
--Mode "Help"
```

### Drug

To run the application starting from an initial drug, you can launch it from the terminal with the `--Mode` argument set to `Drug`, for example:

```
--Mode "Drug"
```

This mode has four mandatory arguments (omitting any of them will return an error) and four optional ones:

* ``--Interactions``. Use this argument to specify the path to the file containing the protein-protein interactions. Each interaction should be on a new line, with its elements separated by semicolons. Each interaction should contain the source protein, the target protein, and the type ("-1" for a down-regulating interaction or equivalent, "1" for an up-regulating interaction or equivalent, or "0" otherwise), for example:
  
  ```
  Protein A;Protein B;-1
  Protein A;Protein C;1
  Protein A;Protein D;1
  Protein C;Protein D;0
  ```
  
  If the file is in a different format, or no proteins or interactions could be found, an error will be returned. The order of the proteins is important, as the network is directed. Thus, `Protein A;Protein B` is not the same as `Protein B;Protein A`, and they can both appear in the network. Any duplicate interactions will be ignored. The set of proteins in the network will be automatically inferred from the set of interactions. This argument does not have a default value.
  
* `--Drugs`. Use this argument to specify the path to the file containing the possible drugs. Each drug should be on a new line, with its elements separated by semicolons. Each drug should contain the drug name, the corresponding drug-target, and the type ("-1" for a drug that down-regulates its drug-target, "1" for a drug that up-regulates its drug-target, or "0" otherwise), for example:
  
  ```
  Drug 1;Protein A;-1
  Drug 3;Protein C;1
  ```
  
  If the file is in a different format, or no drugs could be found with drug-targets in the network, an error will be returned. Only the drugs with drug-targets in the network will be considered. Any duplicate drugs will be ignored. This argument does not have a default value.
  
* `--DiseaseEssentialProteins`. (optional) Use this argument to specify the path to the file containing the disease-essential proteins. Each protein should be on a new line.
  
  ```
  Protein A
  Protein D
  ```
  
  If the file is in a different format, or no proteins could be found in the network, an error will be returned. Only the proteins which already appear in the network will be considered. Any duplicate proteins will be ignored. This argument does not have a default value and can be omitted if healthy-essential proteins are provided.
  
* `--HealthyEssentialProteins`. (optional) Use this argument to specify the path to the file containing the healthy-essential proteins. Each protein should be on a new line.
  
  ```
  Protein B
  Protein C
  ```
  
  If the file is in a different format, or no proteins could be found in the network, an error will be returned. Only the proteins which already appear in the network will be considered. Any duplicate proteins will be ignored. This argument does not have a default value and can be omitted if disease-essential proteins are provided.

* `--Initial`. Use this argument to specify the name of the initial drug or drug-target. If the initial drug is not in the list of drugs or its corresponding drug-target does not appear in the network, an error will be returned. This argument does not have a default value.

* `--MaximumPath`. (optional) Use this argument to specify the length of the maximum path between the drug-targets and the essential proteins. It must be a positive integer. The default value is "3".

* `--NumberOfSolutions`. (optional) Use this argument to specify the maximum number of complementing drugs to be returned. The default value is "10".

* `--Output`. (optional) Use this argument to specify the path to the output file where the details about the complementing drugs will be written. Permission to write is needed for the corresponding folder. If a file with the same name already exists, it will be automatically overwritten. The default value is the name of the file containing the interactions, followed by the name of the initial drug, the name of its drug-target, and the current date and time.

### Proteins

To run the application starting from an initial list of proteins, you can launch it from the terminal with the `--Mode` argument set to `Proteins`, for example:

```
--Mode "Proteins"
```

This mode has four mandatory arguments (omitting any of them will return an error) and four optional ones:

* ``--Interactions``. Use this argument to specify the path to the file containing the protein-protein interactions. Each interaction should be on a new line, with its elements separated by semicolons. Each interaction should contain the source protein, the target protein, and the type ("-1" for a down-regulating interaction or equivalent, "1" for an up-regulating interaction or equivalent, or "0" otherwise), for example:
  
  ```
  Protein A;Protein B;-1
  Protein A;Protein C;1
  Protein A;Protein D;1
  Protein C;Protein D;0
  ```
  
  If the file is in a different format, or no proteins or interactions could be found, an error will be returned. The order of the proteins is important, as the network is directed. Thus, `Protein A;Protein B` is not the same as `Protein B;Protein A`, and they can both appear in the network. Any duplicate interactions will be ignored. The set of proteins in the network will be automatically inferred from the set of interactions. This argument does not have a default value.
  
* `--Drugs`. Use this argument to specify the path to the file containing the possible drugs. Each drug should be on a new line, with its elements separated by semicolons. Each drug should contain the drug name, the corresponding drug-target, and the type ("-1" for a drug that down-regulates its drug-target, "1" for a drug that up-regulates its drug-target, or "0" otherwise), for example:
  
  ```
  Drug 1;Protein A;-1
  Drug 3;Protein C;1
  ```
  
  If the file is in a different format, or no drugs could be found with drug-targets in the network, an error will be returned. Only the drugs with drug-targets in the network will be considered. Any duplicate drugs will be ignored. This argument does not have a default value.
  
* `--DiseaseEssentialProteins`. (optional) Use this argument to specify the path to the file containing the disease-essential proteins. Each protein should be on a new line.
  
  ```
  Protein A
  Protein D
  ```
  
  If the file is in a different format, or no proteins could be found in the network, an error will be returned. Only the proteins which already appear in the network will be considered. Any duplicate proteins will be ignored. This argument does not have a default value and can be omitted if healthy-essential proteins are provided.
  
* `--HealthyEssentialProteins`. (optional) Use this argument to specify the path to the file containing the healthy-essential proteins. Each protein should be on a new line.
  
  ```
  Protein B
  Protein C
  ```
  
  If the file is in a different format, or no proteins could be found in the network, an error will be returned. Only the proteins which already appear in the network will be considered. Any duplicate proteins will be ignored. This argument does not have a default value and can be omitted if disease-essential proteins are provided.

* `--Initial`. Use this argument to specify the path to the file containing the initial proteins. Each protein should be on a new line.
  
  ```
  Protein A
  Protein C
  ```
  
  If the file is in a different format, or no proteins could be found in the network, an error will be returned. Only the proteins which already appear in the network will be considered. Any duplicate proteins will be ignored. This argument does not have a default value.

* `--MaximumPath`. (optional) Use this argument to specify the length of the maximum path between the drug-targets and the essential proteins. It must be a positive integer. The default value is "3".

* `--NumberOfSolutions`. (optional) Use this argument to specify the maximum number of complementing drugs to be returned. The default value is "10".

* `--Output`. (optional) Use this argument to specify the path to the output file where the details about the complementing drugs will be written. Permission to write is needed for the corresponding folder. If a file with the same name already exists, it will be automatically overwritten. The default value is the name of the file containing the interactions, followed by the name of the initial drug, the name of its drug-target, and the current date and time.
