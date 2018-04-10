CREATE TABLE public.new_users AS
SELECT 
  date, 
  Count(fl.*) * 10 AS count
FROM 
  events.first_launch,
  (SELECT DISTINCT (udid) FROM events.first_launch) AS fl 
GROUP BY 
  date
ORDER BY
  date;