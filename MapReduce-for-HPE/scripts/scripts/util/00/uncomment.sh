#!/bin/bash
P1="\/\/"
P2=""

OLD1=$P1"System.Console.Write"
NEW1=$P2"System.Console.Write"
find . -iname *.cs | xargs sed -i 's/'"$OLD1"'/'"$NEW1"'/g'

OLD2=$P1"Console.Write"
NEW2=$P2"Console.Write"
find . -iname *.cs | xargs sed -i 's/'"$OLD2"'/'"$NEW2"'/g'

OLD3=$P1"Trace.Write"
NEW3=$P2"Trace.Write"
find . -iname *.cs | xargs sed -i 's/'"$OLD3"'/'"$NEW3"'/g'


