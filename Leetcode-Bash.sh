# 195. Tenth Line (Easy)
cat file.txt | sed -n '10p'


# 193. Valid Phone Numbers (Easy)
sed -n -r '/^([0-9]{3}-|\([0-9]{3}\) )[0-9]{3}-[0-9]{4}$/p' file.txt


# 192. Word Frequency (Medium)
cat words.txt | awk -F ' '  '{for(i=1;i<=NF;i++) print $i }' | sort | uniq -c | sort -n -r | awk -F ' ' '{print $2, $1}' 




# 194. Transpose File (Medium)
awk '
{
    for (i = 1; i <= NF; i++) {
        if (FNR == 1) {
            t[i] = $i;
        } else {
            t[i] = t[i] " " $i
        }
    }
}

END {
    for (i = 1; t[i] != ""; i++) {
        print t[i]
    }
}
' file.txt