CREATE TABLE gender.dau AS
SELECT 
  gender,
  date,
  Count(*) * 10 AS count
FROM 
  parameters.first_launch,
  events.first_launch
GROUP BY 
  gender,
  date
ORDER BY
  gender,
  date;