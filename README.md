# County Quiz Croatia
## A simple practice application for creating interactive maps using XAML

The application has two modes:
- Info mode: Click on a county to see its name and some extra details
- Quiz mode: Receive a name of a county and try to find it on the map

Switching between modes resets them, to prevent cheating.

<img src="https://i.imgur.com/2CAfJN4.png" alt="Info mode" width="75%" height="75%">
<img src="https://i.imgur.com/UQI4OSe.png" alt="Quiz mode" width="75%" height="75%">

### Vector graphics to XAML
The easiest way to get paths from a vector graphics image inside your XAML file (in this case a *UserControl*), is to use [Inkscape](https://inkscape.org/), because of its handy save option: *Save as Microsoft XAML*.
The resulting file will contain more data than you need, so feel free to trim it down, the most important things to keep are the *PathGeometry* blocks.

### Application info
- .NET Core 5.0, WPF (Windows Presentation Foundation).  
- Uses the awesome [Stylet](https://github.com/canton7/Stylet) MVVM framework, and its *StyletIoC* IoC container for dependency injection.  
- SVG map of Croatia from [amCharts](https://www.amcharts.com/svg-maps/?map=croatia).  
- Application icon by [Deedster](https://pixabay.com/users/deedster-2541644/?utm_source=link-attribution&amp;utm_medium=referral&amp;utm_campaign=image&amp;utm_content=2039124) from [Pixabay](https://pixabay.com/images/id-2039124/).  
