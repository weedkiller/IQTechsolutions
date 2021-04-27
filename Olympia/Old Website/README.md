# Olympia Portal

## Fonts

- (Cinzel)[https://fonts.google.com/specimen/Cinzel?selection.family=Cinzel]
- (Roboto)[]

Use the following tool to download google fonts:
(google-webfonts-helper)[https://google-webfonts-helper.herokuapp.com/fonts]

## Sections

### 1 - Introduction (what)

Designed for the workplace, **OLYMPIA** is an employee management
platform the leverages gamification to increase employee performance,
recognition and engagement.

- Open video in modal

### 2 - Benfits (why)

Company Benefits
- More Revenue
- Employee Retention
- Customer Satisfaction

Team Benefits
- TODO

Employee Benefits
- More Engaged
- More Productive

### 3 - How

Leaderboards
- Daily, Weekly and All Time

Ad Hoc Points
- Exceptional Performance
- Long Term Accomplishments

Visibility
- Users
- Teams

Activites
- Once Off Activites
- Recurring Activities

Workflows And Forms
- Workflows
- Forms

### Gamification

- Onboarding And Team Anniversary Activies
- Birthday Activities
- Adhoc Points for Exceptional Performance or Long Term Accomplishments.
- Leaderboards

### How It Works

- Defines your leaderbaords
- Define your workflows
- Define your activities
- Employees connect to complete their activities and get real time feedback
- Iterate and improve

### More Than Gamification

- Stats
- 

### Our customers

-
-

### Footers

- call
- visit
- email

### S3 Bucket Policy

{
    "Version": "2012-10-17",
    "Id": "S3PolicyId1",
    "Statement": [
        {
            "Sid": "IPAllow",
            "Effect": "Deny",
            "Principal": "*",
            "Action": "s3:*",
            "Resource": "arn:aws:s3:::www.olympia.team/*",
            "Condition": {
                "NotIpAddress": {
                    "aws:SourceIp": "197.185.248.119/32"
                },
                "StringNotEquals": {
                    "aws:Referer": "cloudfront"
                }
            }
        }
    ]
}