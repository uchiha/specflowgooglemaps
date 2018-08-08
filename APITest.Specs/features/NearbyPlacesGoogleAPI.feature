Feature: NearbyPlacesGoogleAPI
	In order to find nearby places
	As a maps frequest user
	I want to be aware of the nearest places of interest from me

Scenario: Find nearest restaurant within the nearest 500m radius of parnell (represented in the longitude/latitude)
	Given I am using the google maps api "https://maps.googleapis.com"
	And access to the "/maps/api/place/nearbysearch/json?" resource with "get" as a method
	And I add parameter "key" with value "AIzaSyBLzFAnW-1XE28hZ2BpJxcpGOquAdBZ8sQ"
	And I add parameter "location" with value "-36.854065,174.779877"
	And I add parameter "type" with value "restaurant"
	And I add parameter "radius" with value "500"
	When I execute the said request
	Then I should have "20" results
