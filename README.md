<div align="center">

<h1>🎨 NR Designs: Design Studio - Portfolio website 🌐</h1>

</div>

---

## 📑Table of Contents

🧭 1. [**Introduction**](#-1-introduction)<br>
🛠️ 2. [**Setting Up the Project Locally**](#️-2-setting-up-the-project-locally)<br>
🏗️ 3. [**Architecture**](#️-3-architecture)<br>
👥 4. [**Author and Contributions**](#-4-author-and-contributions)<br>
⚖️ 5. [**MIT License**](#️-5-mit-license)<br>

---

## 🧭 1. Introduction

This application serves as a digital home for **NR Designs**, a **Durban-based creative studio**. The studio specializes in innovative **graphic design**, ranging from television prop design for major South African shows to corporate branding and digital media. The website is architected as a **static single-page application (SPA)** within the **MVC framework**, leveraging **anchor links** for seamless section transitions and a focused user experience.

### Key Features:

- **Anchor Links**: Implements a smooth-scroll navigation system that maps the header menu to specific `id` attributes on the single `.cshtml` page, ensuring users can navigate from "Introduction" to "Services" without page reloads.
- **Card Animations**: Utilizes CSS3 transitions and transforms to create a dynamic gallery; hovering over design pieces triggers scale increases and box-shadow glows for a premium feel.
- **Seamless Image Transitions**: Employs JavaScript or CSS-based sliders within individual project cards, allowing visitors to cycle through various works without leaving the current view.
- **Whatsapp Redirect**: Integrates a direct communication link using the studio's contact number via the WhatsApp icon in the bottom right (API), enabling potential clients to initiate a chat instantly from the browser.
- **Brevo Email API (SMTP)**: Configures an SMTP relay or API integration using Brevo (formerly Sendinblue) to handle the contact form, allowing users to send inquiries directly to NR Designs securely.
- **Google Maps Embedded Link**: Features an embedded map component pinpointing NR Designs' location in Durban, optimized for performance by using a static map image or cached iframe to reduce load times.
- **Product and Services showcase**: A comprehensive, categorized display of the studio's diverse offerings, including Prop Design, Business Branding, and Social Media Marketing, structured to mirror the professional flow of the 2025 portfolio.

---

## 🛠️ 2. Setting Up the Project Locally

> ⚠️ **Note**: Application still in development

### Prerequisites:

To successfully compile and run this project, you must have the following installed on your system:

- **Operating Systems**: Any OS compatible with the .NET 9.0 Runtime and the corresponding SDK. This generally includes modern versions of Windows (Windows 10/11), macOS 10.15+, or Linux distributions that support the .NET 9 framework.
- **IDE**: Compatible version of Microsoft Visual Studio 2019+ (or an equivalent IDE like VS Code with extensions, such as C# Dev Kit).
- **Version Control**: Git for cloning the repository.
- **Database**: SQL Server instance (either local or remote) is necessary to integrate with the main data store.
- **Frameworks**:
  - Target Framework: .NET 9.0 (net9.0)
  - Web Framework: ASP.NET Core 9.0
- **RAM**: Minimum 4GB
- **Disk Space**: Minimum 200MB free space
- **Dependencies**:
  - NRDesigns.csproj:
    - Newtonsoft.Json (Version: 13.0.4)

### Project Configurations

#### `NRDesigns.csproj`

This configuration defines the project as an **ASP.NET Core web application** targeting the **latest framework version**.

```xml
<Project Sdk="Microsoft.NET.Sdk.Web">

  <PropertyGroup>
    <TargetFramework>net9.0</TargetFramework>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
  </PropertyGroup>

  <ItemGroup>
  </ItemGroup>

  <ItemGroup>
    <PackageReference Include="Newtonsoft.Json" Version="13.0.4" />
  </ItemGroup>

</Project>

```

#### `appsettings.json`

This configuration stores **connection strings**, **custom settings**, and **logging configuration**, which are loaded at runtime.

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",

  "Brevo": {
    "ApiKey": "YOUR_BREVO_API_KEY_HERE"
  }
}
```

### Installation

Follow these steps to get the application running on your local machine.

#### 1. Clone the Repository

- Naviagte and click the green "**Code**" button at the top of this repository.
- Copy the URL under the "**HTTPS**" tab (`https://github.com/singhishkar108/NR-Designs.git`).
- Navigate to the directory where you want to save the project (e.g., `cd Documents/Projects`).
- Open your preferred terminal or command prompt and use the following command to clone the project:

```bash
git clone https://github.com/singhishkar108/NR-Designs.git
```

- This will create a new folder with the repository's name and download all the files and the entire history into it.
- Alternatively, you may download as a **ZIP file** or clone using **GitHub Desktop**.

#### 2. Open in Visual Studio (Recommended)

1.  Open **Visual Studio 2022**.
2.  Navigate to **File \> Open \> Project/Solution**.
3.  Browse to the cloned repository and select the **Solution file (.sln)** to load the project.
4.  Visual Studio will automatically perform a package restore (`dotnet restore`).

The application will launch. You should see a message in the console indicating the application is running. The browser should open automatically to the default URL.

#### 3. Add Your Brevo API Key

- The authentication system requires your own **Brevo API key**.
- You must add this in your configuration (e.g., appsettings.json, environment variables, or injected configuration) before running the application.

Example placeholder:

```json
"Brevo": {
  "ApiKey": "YOUR_BREVO_API_KEY_HERE"
}
```

- Your placeholder value will be inserted in `Controllers/HomeController`.
- Make sure your controllers or services read this value properly.

> ❌ **DO NOT** commit real API keys to GitHub <br>
> ⚠️ **Note**: As the application is currently in it's development purposes, API credentials are currently configured within the `appsettings.json` file.
> This approach is **not recommended** for production environments. In a real deployment, securely store secrets using environment variables, cloud secret managers (e.g. Azure Key Vault, AWS Secrets Manager, or GCP Secret Manager), or production configuration files. Reserve User Secrets for local development only, and always exclude sensitive files from version control.

### Running

#### 1. Run in Visual Studio

1.  Select **Build \> Build Solution** (or press `F6`) to compile the project.
2.  Click the **Run** button (or press `F5`) to start the application with debugging, or `Ctrl+F5` to start without debugging.

#### 2. Run via Command Line (Alternative)

If you are using **Visual Studio Code** or prefer the CLI:

1.  Navigate to the project directory containing the `.csproj` file.
2.  Execute the following commands in sequence:

```bash
# Clean up any previous build files
dotnet clean

# Restore project dependencies
dotnet restore

# Build and run the application
dotnet run
```

#### 4. Access the Application

- The console output will indicate the local URL where the application is hosted (e.g., `https://localhost:7198`).
- Open your web browser and navigate to the displayed URL (e.g., `https://localhost:7198`). You should now see the **NR Designs home page**.

---

## 🏗️ 3. Architecture

### Application Structure (ASP.NET Core MVC)

The application code adheres to the **MVC pattern**, which ensures a clear separation of concerns, making the codebase maintainable, testable, and scalable.

- **Model**: This layer manages the application's data and business logic. It includes the Entity Framework Core data context, the entity classes (e.g., Product, Order), and the service classes responsible for interacting with the database and external Azure APIs.
- **View**: The user interface (UI) is rendered using Razor views. This layer is responsible solely for presenting the data to the client and capturing user input.
- **Controller**: Controllers act as the entry point for handling user requests. They receive input, coordinate the necessary actions by calling methods in the Model layer, and determine which View to return to the user.

---

## 👥 4. Author and Contributions

### Primary Developer:

- I, **_Ishkar Singh_**, am the sole developer and author of this project:
  Email (for feedback or concerns): **ishkar.singh.108@gmail.com**

### Reporting Issues:

- If you encounter any bugs, glitches, or unexpected behaviour, please open an Issue on the GitHub repository.
- Provide as much detail as possible, including:
  - Steps to reproduce the issue
  - Error messages (if any)
  - Screenshots or logs (if applicable)
  - Expected vs. actual behaviour
- Clear and descriptive reports help improve the project effectively.

### Proposing Enhancements:

- Suggestions for improvements or feature enhancements are encouraged.
- You may open a Discussion or submit an Issue describing the proposed change.
- All ideas will be reviewed and considered for future updates.

---

## ⚖️ 5. MIT License

**Copyright © 2026 Ishkar Singh**<br>

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), being limited strictly to the source code of this repository, to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

For the avoidance of doubt, the term "Software" as used herein expressly excludes any non-code assets, including but not limited to the business name “NR Designs”, all trademarks, service marks, logos, branding elements, images, graphics, illustrations, marketing or promotional materials, design work, portfolios, client materials, and any third-party names, brands, trademarks, or other proprietary content, all of which remain the exclusive property of their respective owners and are not licensed under this License.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
