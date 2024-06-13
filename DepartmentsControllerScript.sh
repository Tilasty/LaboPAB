#!/bin/bash

# Test GetDepartments
echo "Testing GET /api/departments"
curl -s -o /dev/null -w "%{http_code}" "$BASE_URL"
echo -e "\n"

# Test GetDepartment by ID
DEPARTMENT_ID=1
echo "Testing GET /api/departments/$DEPARTMENT_ID"
curl -s -o /dev/null -w "%{http_code}" "$BASE_URL/$DEPARTMENT_ID"
echo -e "\n"

# Test CreateDepartment
echo "Testing POST /api/departments"
NEW_DEPARTMENT='{"Name":"New Department"}'
curl -s -o /dev/null -w "%{http_code}" -X POST -H "Content-Type: application/json" -d "$NEW_DEPARTMENT" "$BASE_URL"
echo -e "\n"

# Test UpdateDepartment
UPDATED_DEPARTMENT='{"Id":1,"Name":"Updated Department"}'
echo "Testing PUT /api/departments/1"
curl -s -o /dev/null -w "%{http_code}" -X PUT -H "Content-Type: application/json" -d "$UPDATED_DEPARTMENT" "$BASE_URL/1"
echo -e "\n"

# Test DeleteDepartment
echo "Testing DELETE /api/departments/1"
curl -s -o /dev/null -w "%{http_code}" -X DELETE "$BASE_URL/1"
echo -e "\n"