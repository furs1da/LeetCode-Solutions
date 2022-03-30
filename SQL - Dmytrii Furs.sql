-- LeetCode SQL - Dmytrii Furs
-- 175. Combine Two Tables (Easy)
SELECT p.firstName, p.lastName, a.city, a.state
FROM Person p
LEFT JOIN Address a 
ON a.personId = p.personId;

-- 176. Second Highest Salary (Medium) SELECT (SELECT ) to avoid nulls 
SELECT (SELECT DISTINCT salary 
FROM employee
ORDER BY salary DESC
LIMIT 1, 1) AS SecondHighestSalary;

-- 177. Nth Highest Salary (Medium)
CREATE FUNCTION getNthHighestSalary(N INT) RETURNS INT
BEGIN
  SET N = N - 1,
  RETURN (
      SELECT IFNULL(
      (SELECT DISTINCT salary
      FROM employee
      ORDER BY salary DESC
      LIMIT N, 1), NULL)
  )
END;

-- 178. Rank Scores (Medium)
SELECT score, DENSE_RANK() OVER (ORDER BY score DESC) AS 'rank'
FROM Scores
ORDER BY score DESC;

-- 180. Consecutive Numbers (Medium)
SELECT DISTINCT l1.Num AS ConsecutiveNums
FROM 
Logs l1, Logs l2, Logs l3
WHERE
l1.id = l2.id - 1
AND l2.id = l3.id - 1
AND l1.num = l2.num
AND l2.num = l3.num;

-- 181. Employees Earning More Than Their Managers (Easy)
SELECT
     a.NAME AS Employee
FROM Employee AS a JOIN Employee AS b
     ON a.ManagerId = b.Id
     AND a.Salary > b.Salary;

-- 182. Duplicate Emails (Easy)
SELECT Email
FROM Person
GROUP BY Email
HAVING COUNT(Email) != 1;

-- 183. Customers Who Never Order (Easy) 
SELECT Customers.name AS 'Customers'
FROM Customers
LEFT JOIN Orders ord 
ON ord.customerId = Customers.id 
WHERE ord.customerId IS NULL;

-- 184. Department Highest Salary (Medium)
SELECT d.name AS 'Department', e.Name AS 'Employee', e.salary
FROM employee e
INNER JOIN department d
ON e.departmentId = d.id
WHERE (e.departmentId, salary) IN
(SELECT 
 departmentId, MAX(salary)
 FROM 
 employee
 GROUP BY departmentId
);

-- 185. Department Top Three Salaries (Hard)
SELECT d.name AS 'Department', e1.name AS 'Employee', e1.salary
FROM employee e1
JOIN Department d 
ON e1.departmentId = d.id
WHERE 3 > 
(
SELECT COUNT(DISTINCT e2.salary)
FROM employee e2
WHERE e2.salary > e1.salary 
AND e1.departmentId = e2.departmentId
);

-- 196. Delete Duplicate Emails (Easy) 
DELETE FROM Person WHERE id NOT IN 
(SELECT * FROM (SELECT MIN(id) FROM person GROUP BY Email) as p);

-- 197. Rising Temperature (Easy) 
SELECT weather.id
FROM weather
JOIN weather w ON DATEDIFF(weather.recordDate, w.recordDate) = 1 AND weather.Temperature > w.Temperature;

-- 262. Trips and Users (Hard)
SELECT Request_at AS Day, ROUND(SUM(IF(status != 'completed',1,0))/COUNT(status),2) AS 'Cancellation Rate'
FROM Trips
WHERE Request_at >= "2013-10-01" AND Request_at <= "2013-10-03"
AND client_id NOT IN (
SELECT users_id FROM users WHERE Banned="Yes")
AND driver_id NOT IN (
SELECT users_id FROM users WHERE Banned="Yes")
GROUP BY Request_at;

-- 601. Human Traffic of Stadium (Hard) (In this task we need to find all consecutive rows, with at least 3 in a row, so  we need to
-- checkk all 3 possible outcomes - 1, 2, 3; 2, 1, 3; 3, 2, 1;
SELECT DISTINCT st1.id, st1.visit_date, st1.people
FROM stadium st1, stadium st2, stadium st3
WHERE 
st1.people >= 100
AND st2.people >= 100
AND st3.people >= 100
AND (
    (st1.id - st2.id = 1 AND st1.id - st3.id = 2 AND st2.id - st3.id = 1)
    OR
    (st2.id - st1.id = 1 AND st2.id - st3.id = 2 AND st1.id - st3.id = 1)
    OR
    (st3.id - st2.id = 1 AND st2.id - st1.id = 1 AND st3.id - st1.id = 2)
)
ORDER BY st1.id;

-- 596. Classes More Than 5 Students (Easy)
SELECT class
FROM courses
GROUP BY class
HAVING COUNT(DISTINCT student) >= 5;

-- 595. Big Countries (Easy) 
SELECT w.name, w.population, w.area
FROM World w
WHERE area >= 3000000 OR population >= 25000000;

-- 620. Not Boring Movies (Easy)
SELECT c.id, c.movie, c.description, c.rating
FROM Cinema c
WHERE c.description != 'boring' AND mod(c.id,2) = 1
ORDER BY rating DESC;

-- 626. Exchange Seats (Medium) 
SELECT 
 (CASE 
 WHEN MOD(id,2) != 0 AND counts != id then id + 1
 WHEN MOD(id,2) != 0 AND counts = id then id
 ELSE id - 1
 END) as id, student
FROM Seat,
(SELECT COUNT(*) AS counts
FROM seat) as seat_counts
ORDER BY id ASC;

--  627. Swap Salary (Easy) 
UPDATE Salary
SET 
    sex = CASE sex 
    WHEN 'm' THEN 'f'
    ELSE 'm'
    END;

-- 1179. Reformat Department Table (Easy) 
SELECT
id,
SUM(IF(month = 'Jan', revenue, NULL)) as Jan_Revenue,
SUM(IF(month = 'Feb', revenue, NULL)) as Feb_Revenue,
SUM(IF(month = 'Mar', revenue, NULL)) as Mar_Revenue,
SUM(IF(month = 'Apr', revenue, NULL)) as Apr_Revenue,
SUM(IF(month = 'May', revenue, NULL)) as May_Revenue,
SUM(IF(month = 'Jun', revenue, NULL)) as Jun_Revenue,
SUM(IF(month = 'Jul', revenue, NULL)) as Jul_Revenue,
SUM(IF(month = 'Aug', revenue, NULL)) as Aug_Revenue,
SUM(IF(month = 'Sep', revenue, NULL)) as Sep_Revenue,
SUM(IF(month = 'Oct', revenue, NULL)) as Oct_Revenue,
SUM(IF(month = 'Nov', revenue, NULL)) as Nov_Revenue,
SUM(IF(month = 'Dec', revenue, NULL)) as Dec_Revenue
FROM Department
GROUP BY id;


-- 586. Customer Placing the Largest Number of Orders (Easy)
SELECT customer_number
FROM orders
GROUP BY customer_number
ORDER BY COUNT(*) DESC
LIMIT 1;

-- 511. Game Play Analysis I
SELECT player_id, MIN(event_date) AS 'first_login'
FROM activity
GROUP BY player_id

-- 584. Find Customer Referee
SELECT name
FROM customer
WHERE referee_id != 2 OR referee_id IS NULL


