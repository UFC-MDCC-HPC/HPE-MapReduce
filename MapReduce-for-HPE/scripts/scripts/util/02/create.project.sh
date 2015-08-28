#!/bin/bash
for folder in teste.*
do 
	echo "<?xml version=\"1.0\" encoding=\"UTF-8\"?><projectDescription><name>" > $folder/.project
	echo $folder >> $folder/.project
        echo "</name><comment></comment><projects></projects><buildSpec><buildCommand><name>org.emonic.base.EMonic_Builder</name>" >> $folder/.project
	echo "<arguments></arguments></buildCommand></buildSpec><natures><nature>org.emonic.base.EMonic_Nature</nature></natures>" >> $folder/.project
	echo "</projectDescription>" >> $folder/.project	 
done;

