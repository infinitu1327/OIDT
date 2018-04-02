SELECT "Date",Count(*)*10 as "Count"
FROM events."FirstLaunch"
GROUP BY "Date";