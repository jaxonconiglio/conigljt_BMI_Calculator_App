using Microsoft.Maui.Controls;


namespace conigljt_BMI_Calculator_App;

public partial class BMICalculatorApp : ContentPage
{

	private string selectGender = "";

	public BMICalculatorApp()
	{
		InitializeComponent();

	}

	private void OnMaleTapped(object sender, EventArgs e)
	{
		selectGender = "Male";
		MaleFrame.BorderColor = Colors.Blue;
		FemaleFrame.BorderColor = Colors.Transparent;
	}

    private void OnFemaleTapped(object sender, EventArgs e)
    {
        selectGender = "Female";
        MaleFrame.BorderColor = Colors.Transparent;
        FemaleFrame.BorderColor = Colors.Pink;
    }

	private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
	{
		WeightLabel.Text = $"{(int)WeightSlider.Value} lbs";
		HeightLabel.Text = $"{(int)HeightSlider.Value} in";
	}

	private void OnCalculateClicked(object sender, EventArgs e)
	{
		if (string.IsNullOrEmpty(selectGender))
		{
			DisplayAlert("Input Error", "Please select your gender.", "OK");
			return;
		}

		double weight = WeightSlider.Value;
		double height = HeightSlider.Value;

		if (height <= 0)
		{
			DisplayAlert("Input Error", "Height must be greater than 0.", "OK");
			return;
		}

		double bmi = (weight / (height * height)) * 703;

		string status = "";
		string recommendation = "";
		
		if (selectGender == "Male")
		{
			if (bmi < 18.5)
			{
				status = "Underweight";
				recommendation = "-Increase calorie intake with nutrient-rich foods (e.g., nuts lean protein, whole grains). " +
					"-Incorporate strength training to build muscle mass. " +
					"-Consult a nutritionist if needed..";
			}
			else if (bmi < 25)
			{
                status = "Normal weight";
                recommendation = "-Maintain a balanced diet with proteins, healthy fats, and fiber. " +
                    "-Stay physically active with at least 150 minutes of exercise per week. " +
					"-Keep regular check ups to monitor overall health.";
            }
			else if (bmi < 30)
			{
                status = "Overweight";
                recommendation = "-Reduce processed foods, and focus on portion control. " +
                    "-Engage in regular aerobic erecises (e.g., jogging, swimming) and strength training. " +
                    "-Drink plenty of water and track your progress.";
            }
			else
			{
                status = "Obese";
                recommendation = "-Consult a doctor for personalized guidance. " +
                    "-Start with low-impact exercises (e.g., walking or cycling). " +
                    "-Follow a structured weight-loss meal plan and consider behavioral therapy for lifestyle changes. " +
                    "-Avoid sugary drinks and maintain a constant sleep schedule.";
            }
		}

		else
		{
			if (bmi < 18)
			{
				status = "Underweight";
				recommendation = "-Increase calorie intake with nutrient-rich foods (e.g., nuts lean protein, whole grains). " +
					"-Incorporate strength training to build muscle mass. " +
					"-Consult a nutritionist if needed..";
			}
			else if (bmi < 25)
			{
				status = "Normal weight";
				recommendation = "-Maintain a balanced diet with proteins, healthy fats, and fiber. " +
					"-Stay physically active with at least 150 minutes of exercise per week. " +
					"-Keep regular check ups to monitor overall health.";
			}
			else if (bmi < 30)
			{
				status = "Overweight";
				recommendation = "-Reduce processed foods, and focus on portion control. " +
					"-Engage in regular aerobic erecises (e.g., jogging, swimming) and strength training. " +
					"-Drink plenty of water and track your progress.";
			}
			else
			{
				status = "Obese";
				recommendation = "-Consult a doctor for personalized guidance. " +
					"-Start with low-impact exercises (e.g., walking or cycling). " +
					"-Follow a structured weight-loss meal plan and consider behavioral therapy for lifestyle changes. " +
					"-Avoid sugary drinks and maintain a constant sleep schedule.";
			}
		}

		string summary = $"Gender: {selectGender}\n"+
			$"BMI: {bmi:F2}\n" +
			$"Status: {status}\n\n" +
			$"Recommendation:\n{recommendation}";

		DisplayAlert("BMI Summary", summary, "OK");

		}
	}