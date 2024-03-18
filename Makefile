docker-up:
	docker-compose up -d

docker-down:
	docker-compose down
healthcheck:
	curl -X 'GET'  'http://localhost:5000/api/HealthChecks' -H 'accept: */*'
get-jwt:
	curl -X 'POST' 'http://localhost:5000/api/Authentication/login'  -H 'accept: */*' -H 'Content-Type: application/json'  -d '{ "email": "user@example.com", "password": "123456" }'
open-swagger:
	open http://localhost:5000/swagger/index.html