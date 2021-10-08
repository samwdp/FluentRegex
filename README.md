
# Table of Contents

1.  [Fluent Regex](#org4926393)
    1.  [Usage](#orgc24211e)



<a id="org4926393"></a>

# Fluent Regex

Ever thought that regex is a bit crap to write. Now it isnt with Fluent Regex.
Create regex search queries quickly and easily.


<a id="orgc24211e"></a>

## Usage

    var result = FluentRegex.Start().MatchFromBeginningOfInput(a =>
    {
        return a.AddSubexpression(b =>
            {
                return b.MatchTab()
                    .AddSubexpression(c => c.MatchCharacterSet("A-Za-z")).EndSubexpression();
            }).EndSubexpression();
    }).AsString();

/<sup>(\t([A-Za-z]))</sup>

