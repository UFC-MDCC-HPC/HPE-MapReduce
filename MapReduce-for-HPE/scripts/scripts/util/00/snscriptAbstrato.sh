#!/bin/bash
for folder in br.ufc.mdcc.mapreduce.example.graph.sssp.*
do 
        pacote=`echo $folder | cut -d'.' -f8`
        echo $folder
        echo $pacote
	sn -k $folder/$pacote.snk
        sn -p $folder/$pacote.snk $folder/$pacote.pub
        ls $folder
done;

