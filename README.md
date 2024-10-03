# Задание номер 3
apiVersion: apps/v1
kind: Deployment
metadata:
   #Не знал какое имя дать, пусть будет my-app
  name: my-app
  labels:
    app: my-app
spec:
  replicas: 3  # Согласно условию задачи, 3 подов достаточно для справления с нагрузкой
  selector:
    matchLabels:
      app: my-app # Указываем какую метку должны иметь поды для доступа к развертыванию
     # Определяет шаблон для создаваемых подов 
  template:
    metadata:
      labels:
        app: my-app
    spec:
      containers:
      - name: my-app-container
        image: my-app:latest  # Имя образа приложения
        ports:
        - containerPort: 80  # Порт, на котором приложение будет слушать

        # Настройки ресурсов
        resources:
          requests:
            memory: "128Mi"  # Минимальная память, которую требует приложение
            cpu: "100m"  # Запрос на 100m CPU для первоначальной инициализации
          limits:
            memory: "128Mi"  # Лимит памяти
            cpu: "200m"  # Лимит CPU, чтобы избежать чрезмерного потребления ресурсов

        # Применяем readinessProbe для проверки готовности пода
        readinessProbe:
          httpGet:
            path: /health  # URL для проверки готовности
            port: 80
          initialDelaySeconds: 10  # Задержка перед первой проверкой
          periodSeconds: 5  # Периодичность проверки готовности

        # Применяем startupProbe для проверки успешной инициализации приложения
        startupProbe:
          httpGet:
            path: /health  # URL для проверки старта
            port: 80
          initialDelaySeconds: 5  # Задержка перед первой проверкой
          periodSeconds: 10  # Периодичность проверки

        # Настройки для уменьшения ресурсов при простое
        lifecycle:
          preStop:
            exec:
              command: ["/bin/sh", "-c", "sleep 5"]  # Даем время на завершение работы приложения
