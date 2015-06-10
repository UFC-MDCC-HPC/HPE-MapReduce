#!/bin/bash
for folder in teste.*
do 
        pacote=`echo $folder | cut -d'.' -f2`
        echo $folder
        echo $pacote
	sn -k $folder/$pacote.snk
        sn -p $folder/$pacote.snk $folder/$pacote.pub
        ls $folder
done;

