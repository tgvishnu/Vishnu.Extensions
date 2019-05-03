# Vishnu.Extensions
## This package supports various algorithms for performing
   - Sorting contents.
   - Pattern searching in strings
## Give a Star! :star:
If you like or are using this project please give it a star. Thanks!


# 1. Sorting

<hr/>

>## Description

 
```c#
    
  // Perform sorting using algorithms defined in DefaultAlgorithm factory
  Algorithm.Sorting.Use{ALGORITHM_NAME}<TYPE>(<TYPE> input, IComparer<TYPE>); 
  
  // Perform sorting using algorithms defined in Custom algorithm factory
  Algorithm.Sorting.Use{ALGORITHM_NAME}<TYPE>(ISortingAlgorithmFactory sortingAlgorithmFactory, <TYPE> input,  IComparer<TYPE>);        
  
  // Peform sorting on strings using algorithms with default IComparer<char>
  string sortedString = Algorithm.Sorting.Use{ALGORITHM_NAME}(string input);
  
  // Perform sorting on string using algorithm with custom IComparer<char>
  string sortedString = Algorithm.Sorting.Use{ALGORITHM_NAME}(string input, {IComparer<char>});
 
```  
   
>## Usage

```c#
     // sorting array of integers
     int[] data = new int[] { 5,3,8,5,1,0,8 };
     Algorithm.Sorting.UseCocktail(data, new IntegerComparer());
     
     // sorting array of string based on the length
     string[] data = new string[] { "hello", null, "i", "am", null, "good", string.Empty, " "};
     Algorithm.Sorting.UseCocktail( data, new StringLengthComparer());
     
     // sorting date time
     DateTime[] data = new DateTime[] { DateTime.Now.AddDays(3), DateTime.Now.AddSeconds(10), DateTime.Now.AddSeconds(-100), DateTime.Now.AddDays(1) };
     Algorithm.Sorting.UseCocktail(data, new DateTimeComparer());
     
     // sorting class based on the custom comparer
     List<Person> people = new List<Person>();
     Algorithm.Sorting.UseCocktail(data, new PersonAgeComparer());    
    
```
>## Available IComparer<T> 

-  AsciiValueComparer
-  DateTimeComparer
-  IntegerComparer
-  StringLengthComparer

Custom comparer must implement IComparer<T> interface
   
IComparer<T> must always
   - return 1 if first element > second element
   - return -1 if first element < second element
   - return 0 if first element == second element
 
```c#

    public class PersonAgeComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            if (x.Age > y.Age)
                return 1;
            if (x.Age < y.Age)
                return -1;
            return 0;
        }
    }

```
>## Supported algorithms

- ** Algorithm.Sorting.UseCocktail**
- ** Algorithm.Sorting.UseBitonic**
- ** Algorithm.Sorting.UseBubble**
- ** Algorithm.Sorting.UseComb**
- ** Algorithm.Sorting.UseCounting**
- ** Algorithm.Sorting.UseHeap**
- ** Algorithm.Sorting.UseInsertion**
- ** Algorithm.Sorting.UseMerge**
- ** Algorithm.Sorting.UsePancake**
- ** Algorithm.Sorting.UseQuickLastPivot**
- ** Algorithm.Sorting.UseRadix**
- ** Algorithm.Sorting.UseSelection**
- ** Algorithm.Sorting.UseShell**
- ** Algorithm.Sorting.UseTim**

>## Extension for adding new Sorting algorithms

New algorithms can be added by extending ** ISorting ** interface using extension methods

```c#
  namespace Vishnu.Extensions.Sorting
  {
      public static class FooAlgorithmSortExtension
      {
          public static void UseFoo<T>(this ISorting sort, T[] input, IComparer<T> comparer)
          {
              // Foo algorithm logic
          }
      }
  }
    
```

 # 2. Pattern Searching

<hr/>

>## Description 

 
```c#

  // Returns list of position of the pattern found in the text based on the algorithm used.    
  IList<int> positions = Algorithm.PatternSearch.Use{ALGORITHNM_NAME} (string text, string pattern)
   
```
>## Usage

```c#

     var text = "THIS IS A TEST TSET";
     var pattern = "TEST";            
     var result = Algorithm.PatternSearch.UseAnagram(text, pattern);  
     
```

>## Supported algorithms

- ** Algorithm.PatternSearch.UseAnagram**
- ** Algorithm.PatternSearch.UseNaive**
- ** Algorithm.PatternSearch.UseKmp**
- ** Algorithm.PatternSearch.UseRabinKrap**
- ** Algorithm.PatternSearch.UseFinateAutomata**
- ** Algorithm.PatternSearch.UseEfficientFinateAutomata**
- ** Algorithm.PatternSearch.UseBitap**
- ** Algorithm.PatternSearch.UseZ**


>## Extension for adding new Pattern searching algorithms

New algorithms can be added by extending ** IPattern ** interface using extension methods

```c#

  namespace Vishnu.Extensions.Pattern
  {
      public static class FooAlgorithmPatternExtension
      {
          public static IList<int> UseFoo(this IPattern patternSearch, string text, string pattern)
          {
              // Foo algorithm logic
          }
      }
  }

```
    
<hr />

# References

1. https://www.geeksforgeeks.org
2. https://www.programmingalgorithms.com

