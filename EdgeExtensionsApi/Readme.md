# Edge extensions api

## Usage
```code
using EdgeExtensionsApi;

var suggestions = await Extensions.GetSuggestions("pdf");
var searchResults = await Extensions.Search("pdf");
var extensionDetail = await Extensions.GetExtensionDetail("eeagobfjdenkkddmbclomhiblgggliao");
```

- [ ] Note: All functions do not accept null values ​​or an empty string, in which case an error will simply be returned.