# INIEditor
 INI File editor software. Currently supports the following format:
 
 The ini file is treated line by line, and organized by groups such as:
 
 `[Group]`
 
 Groups have a name which is the string between `[]`. Every group contains at least one key, every key is on a different line, and has a name and a value, both treated as strings and separated by a `=` without spaces. The value itself is everything contained between `=` and EOL. 
  
  ```
  AlphabeticKey=Hello
  AlphabeticKeyWithSpaces=Hello world!
  NumericKey=15
  AlphanumericKey=I Have 3 Ducks
  MixedKey="15.3 Quick foxes jump over sleepy@dog.com"
  ```
  Values are trated as strings and can represent anything including numbers or symbols, only limited by the encoding used.
 
It is posible to comment on a key by adding a previous line starting by `#`. The comment is the string after the '#' until EOL.

```
#I'm not sure that was the phrase, but I had to add symbols and numbers
MixedKey="15.3 Quick foxes jump over sleepy@dog.com"
```
 
 Ini file example:
 ```
 [GroupName1]
 #Comment on 'KeyName1'
 KeyName1=Value1
 KeyName2=Value2
 [GroupName1]
  #Comment on 'KeyName3'
 KeyName3=Value3
 ```

Empty lines and foward whitespaces are ignored, any format differences will cause the program not to work as intended or at all.

Future updates will include:
```
✓ Group editing and deleting
✓ Highligthing of added/edited/removed keys
✓ Search by key name
✓ Search by key value
✓ Search by comment
✓  Comment support
✗ Support for creating INI files from scratch
✗ Better UI feedback (messageboxes on save, warnings on closing etc)
✗ Format errors and exception handling
````

UI image:

![picture](img/1.png)
