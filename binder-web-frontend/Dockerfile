FROM node:18.10.0 as builder
WORKDIR /app

COPY package.json package-lock.json ./

RUN npm install

COPY . .

EXPOSE 4200

ENV PORT 4200

CMD ["npm", "run", "dev"]
