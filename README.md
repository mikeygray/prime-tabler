# prime-tabler
Application that builds a multiplication table from n sequential prime numbers

Intro
-----
This is a small project designed to build multiplication tables from sequential primes. It's comprised of a model for the problem, accompanying test suite, a console based UI and a web app UI. I've included both UI's as they both have pros and cons. The console is relatively speedy at getting results to the screen, but for larger tables displays them poorly. The WebUI displays the data well regardless, but for larger results suffers serious slowdown and even out of memory exceptions or crashing.

Its written in C# using MSTest and ASP.NET MVC5. All of these were chosen predominatley for speed of implementation

How to run it
-------------
Only runs on Windows.
Open up the solution in Visual Studio (built and tested in VS Community 2015). Package information is included so theoretically there shouldn't be anything extra to install or setup. For the console app select the "PrimeTablerConsole" project and hit run. For the web app select "PrimeTablerWeb" project and if IISExpress is installed you should also only need to hit run. If not, either install it or set up a local website through the Windows IIS settings.

What you’re pleased with
------------------------
 - Prime calculating speed of the simpler algorithm. I was expecting to have to implement a prime sieve (example https://en.wikipedia.org/wiki/Sieve_of_Atkin)!
 - My choices in terms of the problem scope allowed speedy development. For example I didn't need a super robust testing framework.
 - ASP.NET MVC has URL routing built in, which was handy when trying things (i.e. going to http://localhost:xxxx/Primes/Index/17 will immediately render the page for 17 primes)

What you would do with it if you had more time
----------------------------------------------
 - Investigate ways to improve web performance, and a better way to display the data to the user. What practices are there for presenting big datasheets?
 - Include "export to csv" functionality
 - Reapproach caching mechanisms, in part to help with web performance
 - Implement multiple prime algorthms and compare them
